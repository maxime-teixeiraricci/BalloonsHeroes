using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowTime : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float time = GameObject.Find("Main").GetComponent<MainScript>().timePlay;
        int mins = (int)(time / 60);
        int secs = (int)(time % 60);
        int cSecs = (int)((time % 1) * 100);
        GetComponent<Text>().text = "Time : " + ((mins < 10)? "0" + mins : ""+mins) + ":" + ((secs < 10) ? "0" + secs : "" + secs) + "." + ((cSecs < 10) ? "0" + cSecs : "" + cSecs);
    }
}
