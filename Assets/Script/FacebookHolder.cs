using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;


public class FacebookHolder : MonoBehaviour
{
    public FriendInfo[] FriendList;

    public GameObject dialogLoggedIn;
    public GameObject dialogLoggedOut;
    public GameObject dialogUserName;
    public GameObject dialogUserImage;

    public Text UserName;
    public Text UserScore;
    public Image UserImage;

    public string UserID;
    public FriendInfo UserInfo;

    public bool publishScore;
    private List<object> scoreList = null;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (publishScore)
        {
            publishScore = false;
        }
        if (FB.IsLoggedIn)
        {
            dialogLoggedIn.SetActive(true);
            dialogLoggedOut.SetActive(false);

        }
        else
        {
            dialogLoggedIn.SetActive(false);
            dialogLoggedOut.SetActive(true);
        }
        UserScore.text = "" + GameObject.Find("Main").GetComponent<MainScript>().personalRecordScore;
    }

    void Awake()
    {
        FB.Init(SetInit, onHideUnity);
    }

    void SetInit()
    {
        if (FB.IsLoggedIn)
        {
            Debug.Log("Is Log !");
            SetScore(GameObject.Find("Main").GetComponent<MainScript>().personalRecordScore);

        }
        else
        {
            Debug.Log("Isn't Log !");
        }
        DealWithFBMenu(FB.IsLoggedIn);
    }

    void onHideUnity(bool isGameShow)
    {
        if (!isGameShow)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void FBLogin()
    {

        FB.LogInWithReadPermissions(new List<string>() { "email" }, AuthCallback);
        FB.LogInWithPublishPermissions(new List<string>() { "publish_actions","user_friends" }, AuthCallback);

    }

    void AuthCallBack(IResult result)
    {
        if (result.Error != null)
        {
            Debug.Log(result.Error);
        }
        else
        {
            if (FB.IsLoggedIn)
            {
                Debug.Log("Is Log !");

            }
            else
            {
                Debug.Log("Isn't Log !");
            }
            DealWithFBMenu(FB.IsLoggedIn);
        }
    }

    void DealWithFBMenu(bool isLoggedIn)
    {
        if (isLoggedIn)
        {

            FB.API("/me?fields=name,id", HttpMethod.GET, DisplayUsername);
            FB.API("/me/score", HttpMethod.GET, MyScore);
            FB.API("/app/scores", HttpMethod.GET, GetFriends);
            FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);

        }
    }

    public void ManualUpdate()
    {
        FB.API("/app/scores", HttpMethod.GET, GetFriends);
    }

    void DisplayUsername(IResult result)
    {
        if (result.Error == null)
        {
            UserName.text = "" + result.ResultDictionary["name"];
            UserID = "" + result.ResultDictionary["id"];
        }
        else
        {
            Debug.Log(result.Error);
        }
    }

    public void SetScore(int score)
    {
        var scoreData = new Dictionary<string, string>();
        scoreData["score"] = score.ToString();
        FB.API("/me/scores", HttpMethod.POST, delegate (IGraphResult result)
        {
            if (result.Error == null)
            {
                print("OK!");
                print("Score Send ! "+scoreData["score"]);
            }
            else
            {
                print("NOT OK!");
            }
        }
        , scoreData);
        print(scoreData["score"]);

    }

    public void GetScore(IResult result)
    {
        scoreList = Util.DeserializeScores(result.ToString());
        foreach (object score in scoreList)
        {

            var entry = (Dictionary<string, object>)score;
            var user = (Dictionary<string, object>)entry["user"];

            print("Nom : " + user["name"].ToString() + " | Score : " + entry["score"].ToString());

        }
    }


    void DisplayProfilePic(IGraphResult result)
    {

        if (result.Texture != null)
        {

            UserImage.sprite = Sprite.Create(result.Texture, new Rect(0, 0, 128, 128), new Vector2());

        }

    }

    void GetFriends(IResult result)
    {
        //print(result.RawResult);
        IDictionary<string, object> dictRes = result.ResultDictionary;
        print("----------------------------");
        print(result.RawResult);
        foreach (var e in dictRes)
        {
            print(e.Key);
        }
        print("----------------------------");
        List<object> value = (List<object>)dictRes["data"];
        print(value[0]);
        FriendList = new FriendInfo[value.Count];
        for (var i = 0; i < value.Count; i++)
        {
            IDictionary<string, object> info = (IDictionary<string, object>)value[i];

            FriendInfo friend = new FriendInfo();
            friend.rank = i + 1;
            friend.FriendScore = System.Int32.Parse("" + info["score"]);

            print("Score : " + info["score"]);
            IDictionary<string, object> user = (IDictionary<string, object>)info["user"];
            friend.FriendName = "" + user["name"];
            friend.FriendID = "" + user["id"];
            FB.API("/" + friend.FriendID + "/picture?type=square&height=128&width=128", HttpMethod.GET, delegate (IGraphResult res)
             {
                 if (res.Texture != null)
                 {

                     friend.FriendImage = Sprite.Create(res.Texture, new Rect(0, 0, 128, 128), new Vector2());

                 }
                 else
                 {
                     print(res);
                 }
             });
            FriendList[i] = friend;
        }


    }
    public void MyScore(IResult result)
    {
        print("Test");
        IDictionary<string, object> dictRes = result.ResultDictionary;
        List<object> value = (List<object>)dictRes["data"];
        print(result.RawResult);
        var entry = (Dictionary<string, object>)value[0];
        var user = (Dictionary<string, object>)entry["user"];
        UserInfo.FriendName = user["name"].ToString();
        UserInfo.FriendScore = System.Int32.Parse(entry["score"].ToString());
        FB.API("/" + user["id"] + "/picture?type=square&height=128&width=128", HttpMethod.GET, delegate (IGraphResult res)
        {
            if (res.Texture != null)
            {

                UserInfo.FriendImage = Sprite.Create(res.Texture, new Rect(0, 0, 128, 128), new Vector2());

            }
            else
            {
                print("ERROR : " + res);
            }
        });


        print("Nom : " + user["name"].ToString() + " | Score : " + entry["score"].ToString());

    }




    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            print("Logged !");
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }
        }
        else
        {
            Debug.Log("User cancelled login");
        }
        DealWithFBMenu(FB.IsLoggedIn);
    }
}

[System.Serializable]

public class FriendInfo
{
    public string FriendID;
    public int rank;
    public int FriendScore;
    public string FriendName;
    public Sprite FriendImage;
}