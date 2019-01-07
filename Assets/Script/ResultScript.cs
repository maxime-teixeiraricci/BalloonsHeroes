using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultScript : MonoBehaviour
{
    public Text scoreText;
    public Text distanceText;
    public Text bonusText;
    public Text gainText;
    public Text highScoreText;

    MainScript mainScript;

	// Use this for initialization
	void Start ()
    {
        mainScript = GameObject.Find("Main").GetComponent<MainScript>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        scoreText.text = "" + (int)mainScript.score + " pts";
        distanceText.text = "" + mainScript.meters + " m";
        bonusText.text = "x 1.0";
        gainText.text = "+" + (int)((mainScript.score / 2000) + (mainScript.meters / 500));
        highScoreText.text = "" + mainScript.personalRecordScore;
	}
}
