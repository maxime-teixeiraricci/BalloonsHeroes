using UnityEngine;
using Facebook.Unity;
using System.Collections;

public class FBHighScore : MonoBehaviour
{
    public GameObject[] FriendSlots;
    public GameObject ConnectText;
    public int page;
    public FriendInfo[] friendList;
    public FacebookHolder fbscript;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ConnectText.SetActive(!FB.IsLoggedIn);
        friendList = fbscript.FriendList;
        for (var i = 0; i < 5; i++)
        {
            if (i + 5 * page < friendList.Length)
            {
                FriendSlots[i].SetActive(true);
                FriendSlots[i].GetComponent<ScoreFriendShow>().currentFriend = friendList[i + 5 * page];
            }
            else
            {
                FriendSlots[i].SetActive(false);
            }
        }
    }

    public void ChangePage(int i)
    {
        int max = (int)((friendList.Length - 1) / 5.0f);
        print(max);
        page = Mathf.Min(max, Mathf.Max(0, page + i));
    }




}
