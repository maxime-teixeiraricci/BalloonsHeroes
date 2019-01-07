using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreFriendShow : MonoBehaviour
{
    public FriendInfo currentFriend;
    public Text FriendScore;
    public Text FriendName;
    public Image FriendImage;
    public Text FriendRank;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        FriendScore.text = ""+currentFriend.FriendScore;
        FriendName.text = "" + currentFriend.FriendName;
        FriendImage.sprite = currentFriend.FriendImage;
        if ((currentFriend.rank % 10) == 1 && currentFriend.rank != 11)
        {
            FriendRank.text = currentFriend.rank + "st";
        }
        else if ((currentFriend.rank % 10) == 2 && currentFriend.rank != 12)
        {
            FriendRank.text = currentFriend.rank + "nd";
        }
        else if ((currentFriend.rank % 10) == 3 && currentFriend.rank != 13)
        {
            FriendRank.text = currentFriend.rank + "rd";
        }
        else
        {
            FriendRank.text = currentFriend.rank + "th";
        }
    }
}
