using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using UnityEngine.Advertisements;


public class MainScript : MonoBehaviour
{
    public bool isInvinsible;
    public int numberGamesBeforeAdd;
    public int numberBalloons;
    public int lives;
    public int highScore;
    public float score;
    public float scoreMult;
    public int coin;
    public float meters;
    public int combo;
    public double coefCombo;
    public float personalRecordMeters;
    public int personalRecordScore;
    public float lastRecordMeters;
    public int lastRecordScore;
    public HeroesSelectionScript heroesListScript;
    public int idPersonalHeroRecordScore;
    public int lastIdHeroUse;
    public Text numberBalloonsText;
    public Text scoreText;
    public Text metersText;
    public Text comboText;
    public Text comboMultText;
    public Text comboCountText;
    public bool testTime;
    public float timePlay;

    public Hero heroPlayer;
    public GameObject liveIcon;

    public HeroesSelectionScript heroesSelectionScript;
    public bool gameStart;

    private float timer;
    private float timerThiefHero;
    // Use this for initialization
    void Start ()
    {
        
        heroesSelectionScript.selectHero = heroesSelectionScript.listOfHeroes[0];
    }
	
	// Update is called once per frame
	void Update ()
    {
        Time.timeScale = (testTime) ? 0 : 1;
        heroPlayer = heroesSelectionScript.selectHero;
        heroPlayer = heroesSelectionScript.listOfHeroes[lastIdHeroUse];
        lastIdHeroUse = heroPlayer.heroID;
        GameObject.Find("Player").GetComponent<SpriteRenderer>().sprite = heroPlayer.heroImage;
        if (lives > 0)
        {
            liveIcon.SetActive(true);
        }
        else
        {
            liveIcon.SetActive(false);
        }
        meters = (int) (8 * GameObject.Find("Player").transform.position.y);
        //float coefCombo = 0.977f * Mathf.Exp(0.103f * combo);
        coefCombo = (1 + 0.1 * (combo - 1));
        
        if (gameStart)
        {
            timePlay += Time.deltaTime;
            score += ((isInvinsible)?2:1)*(Time.deltaTime * (numberBalloons + 1) * 0.25f) * (float)coefCombo * heroPlayer.heroStat.scoreMult;


            if (heroPlayer.heroID == 9)
            {
                timer += Time.deltaTime;
                if (timer >= timerThiefHero)
                {
                    numberBalloons -= 1;
                    timerThiefHero *= 0.995f;
                    print(timerThiefHero);
                    timerThiefHero = Mathf.Max(0.5f, timerThiefHero);
                   timer = 0;
                    if (numberBalloons < 0)
                    {
                        personalRecordMeters = Mathf.Max(personalRecordMeters, meters);
                        personalRecordScore = (int)Mathf.Max(personalRecordScore, score);
                        lastRecordMeters = meters;
                        coin += (int)((score / 2000) + (meters / 500));

                        gameStart = false;
                        Save();
                        GameObject.Find("Canvas").GetComponent<HUDManager>().ActivateMenu(2);
                    }
                }
            }


        }

        GameObject linePersonalBest = GameObject.Find("Personal Best");
        GameObject linePersonalLast = GameObject.Find("Personal Last");
        if (GameObject.Find("Main").GetComponent<MainScript>().personalRecordMeters != 0)
        {
            linePersonalBest.transform.position = new Vector3(0, GameObject.Find("Main").GetComponent<MainScript>().personalRecordMeters / 8f, 2);
        }
        else
        {
            linePersonalBest.transform.position = new Vector3(0, -5, 2);
        }
        if (GameObject.Find("Main").GetComponent<MainScript>().lastRecordMeters != 0)
        {
            linePersonalLast.transform.position = new Vector3(0, GameObject.Find("Main").GetComponent<MainScript>().lastRecordMeters / 8f, 2);
        }
        else
        {
            linePersonalLast.transform.position = new Vector3(0, -5, 2);
        }
    }

    public void Save ()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfoV2.bbdat");
        GameInfo data = new GameInfo();
        data.personalRecordMeters = personalRecordMeters;
        data.personalRecordScore = personalRecordScore;
        data.lastRecordMeters = lastRecordMeters;
        data.lastRecordScore = lastRecordScore;
        data.coin = coin;
        data.lastIdHeroUse = lastIdHeroUse;
        bf.Serialize(file, data);
        print("Fichier sauvé [ " + Application.persistentDataPath + "/gameInfoV2.bbdat ]");
        file.Close();
        GameObject.Find("FacebookHolder").GetComponent<FacebookHolder>().SetScore(personalRecordScore);
        GameObject.Find("FacebookHolder").GetComponent<FacebookHolder>().ManualUpdate();
    }
    public void Load ()
    {
        if (File.Exists(Application.persistentDataPath + "/gameInfoV2.bbdat"))
        {
            print("Fichier chargé [ "+ Application.persistentDataPath + "/gameInfoV2.bbdat ]");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfoV2.bbdat", FileMode.Open);
            GameInfo data = (GameInfo)bf.Deserialize(file);
            personalRecordMeters = data.personalRecordMeters;
            personalRecordScore = data.personalRecordScore;
            lastRecordMeters = data.lastRecordMeters;
            lastRecordScore = data.lastRecordScore;
            coin = data.coin;
            //heroPlayer = heroesListScript.listOfHeroes[data.lastIdHeroUse];
            //playerdata.lastIdHeroUse;
            idPersonalHeroRecordScore = data.HeroRecord;
            // heroPlayer = data.lastHeroUse;
            heroPlayer = heroesSelectionScript.listOfHeroes[data.lastIdHeroUse];
            file.Close();
        }
        else
        {
            print("Aucun fichier de sauvegarde");
        }
        GameObject.Find("FacebookHolder").GetComponent<FacebookHolder>().SetScore(personalRecordScore);
        GameObject.Find("FacebookHolder").GetComponent<FacebookHolder>().ManualUpdate();
    }

    public void InitializeGame()
    {
        timePlay = 0;
        GameObject.Find("Player").transform.position = new Vector3(0, 0, 0);
        GameObject.Find("Map").GetComponent<MapRandom>().currentCreate = 10f;
        GameObject.Find("Map").GetComponent<MapRandom>().mapLimitCreate = 15f;
        score = 0;
        timerThiefHero = 1.5f;
        numberBalloons = heroPlayer.heroStat.startBalloons;
        lives = heroPlayer.heroStat.startingLive;
        meters = 0;
        combo = 0;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Object"))
        {
            Destroy(obj);
        }
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

}

[System.Serializable]
class GameInfo
{

    public float personalRecordMeters;
    public int lastIdHeroUse;
    public int HeroRecord;
    public int personalRecordScore;
    public float lastRecordMeters;
    public int lastRecordScore;
    public int coin;
    public string playerName;
}

class LanguageText
{
    public string[] languageText;
}
