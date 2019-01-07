using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDManager : MonoBehaviour {
    public AudioClip clickSound;
    public AudioSource source;
    public AudioClip gameMusic;
    public AudioClip menuMusic;

    public Text scoreHUD;
    public Text coinHUD;
    public Text balloonHUD;
    public Text metersHUD;
    public Text comboText;
    public Text comboMultText;
    public Text comboCountText;
    public Text highScoreText;
    public Text multScoreText;

    public GameObject gameHUD ;
    public GameObject menuHUD ;
    public GameObject gameOverHUD;

    public GameObject[] menuList;
    public bool gamePlay;
    public bool menu;
    public bool gameOver;

    MainScript mainScript;

	void Start ()
    {
        mainScript = GameObject.Find("Main").GetComponent<MainScript>();
        gameHUD = GameObject.Find("Game HUD");
        menuHUD = GameObject.Find("Menu HUD");
        gameOverHUD = GameObject.Find("GameOver HUD");
        mainScript.Load();
        ActivateMenu(1);
    }
	
	// Update is called once per frame
	void Update ()
    {
        scoreHUD.text = "" + (int)mainScript.score;
        coinHUD.text = "" + mainScript.coin;
        balloonHUD.text = "" + mainScript.numberBalloons;
        metersHUD.text = "" + mainScript.meters + "m";
        highScoreText.text = "HI : " + mainScript.personalRecordScore;
        multScoreText.text = "x" + mainScript.heroPlayer.heroStat.scoreMult;

        if (mainScript.combo > 1)
        {
            comboText.gameObject.SetActive(true);
            comboMultText.color = GameObject.Find("BalloonCount").GetComponent<Image>().color;
            comboCountText.color = GameObject.Find("BalloonCount").GetComponent<Image>().color;
            comboCountText.text = "" + mainScript.combo;
            comboMultText.text = "x" + ((int)(mainScript.coefCombo * 10)) / 10f;
        }
        else
        {
            comboText.gameObject.SetActive(false);
        }

    
    }

    public void ActivateMenu (int idMenu)
    {

        for (int i = 0; i < menuList.Length; i ++)
        {
            if (i == idMenu)
            {
                menuList[i].SetActive(true);
            }
            else
            {
                menuList[i].SetActive(false);
            }


            if (idMenu != 1 && idMenu != 2)
            {
                source.PlayOneShot(clickSound, 0.5f);
            }

            if (idMenu == 0 || idMenu == 4)
            {
                source.clip = gameMusic;
            }
            else
            {
                source.clip = menuMusic;

            }
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
    }
}
