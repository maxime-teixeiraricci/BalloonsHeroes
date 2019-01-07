using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroesSelectionScript : MonoBehaviour
{
    public Hero[] listOfHeroes;
    public GameObject[] heroesSlot;
    public int page;
    public Sprite unknownHero;

    public Hero selectHero;

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        MainScript mainScript = GameObject.Find("Main").GetComponent<MainScript>();
	}

    public void ChangePage(int i)
    {
        
        page = (page + i) % (1+((listOfHeroes.Length - 1) / 8));
        if (page == -1)
        {
            page = (listOfHeroes.Length - 1) / 8;
        }
    }

    //public void HeroesButtonSelect(int idButton)
    //{
    //    if (listOfHeroes[idButton + 8 * page].unlock)
    //    {
    //        MainScript mainScript = GameObject.Find("Main").GetComponent<MainScript>();
    //        selectHero = listOfHeroes[idButton + 8 * page];
    //        mainScript.lastIdHeroUse = selectHero.heroID;
    //    }
    //}
}

[System.Serializable]
public class Hero
{
    public int heroID;
    public Sprite heroImage;
    public string heroName;
    public string heroBonus;
    public string heroMalus;
    public bool unlock;
    public HeroStat heroStat;
}
[System.Serializable]
public class HeroStat
{
    
    public int startBalloons;
    public Color[] balloonsColorList;
    public int startingLive;
    [Range(0f,5f)]
    public float scoreMult;
    [Range(0f, 5f)]
    public float probBalloonsModify;
    [Range(0f, 5f)]
    public float probBalloons2Modify;
    [Range(0f, 5f)]
    public float probBalloons5Modify;
    [Range(0f, 5f)]
    public float probBalloons10Modify;
    [Range(0f, 5f)]
    public float probSpikeModify;
    [Range(0f, 5f)]
    public float probCoinsModify;
    [Range(0f, 5f)]
    public float probCloudsModify;
    [Range(0f, 5f)]
    public float probHeartBalloonsModify;
    [Range(0f, 5f)]
    public float probStarBalloonsModify;
}
