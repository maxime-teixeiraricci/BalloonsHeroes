using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonHeroesSelect : MonoBehaviour {
    public int idButton;
    public int idHero;
    public HeroesSelectionScript heroesScript;
    public Hero buttonHero;
    public Sprite unknowHero;
    MainScript mainScript;

    // Use this for initialization
    void Start () {
        mainScript = GameObject.Find("Main").GetComponent<MainScript>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        idHero = idButton + heroesScript.page * 8;
        
        GetComponent<Button>().interactable = (buttonHero == heroesScript.selectHero) ? false : true;
        if (idHero < heroesScript.listOfHeroes.Length && heroesScript.listOfHeroes[idHero].unlock)
        {
            idHero = idButton + heroesScript.page * 8;
            buttonHero = heroesScript.listOfHeroes[idButton + heroesScript.page * 8];
            GetComponent<Image>().sprite = buttonHero.heroImage;
        }
        else
        {
            GetComponent<Image>().sprite = unknowHero;
        }
        GetComponent<Button>().interactable = (heroesScript.listOfHeroes[idButton + heroesScript.page * 8] == mainScript.heroPlayer) ? false : true;

    }

    public void HeroesButtonSelect(int id)
    {
        if (heroesScript.listOfHeroes[id + 8 * heroesScript.page].unlock)
        {
            print(heroesScript.listOfHeroes[id + 8 * heroesScript.page].heroName);
            
            mainScript.heroPlayer = heroesScript.listOfHeroes[id + 8 * heroesScript.page];
            heroesScript.selectHero = heroesScript.listOfHeroes[id + 8 * heroesScript.page];
            mainScript.lastIdHeroUse = heroesScript.listOfHeroes[id + 8 * heroesScript.page].heroID;
        }
    }


}
