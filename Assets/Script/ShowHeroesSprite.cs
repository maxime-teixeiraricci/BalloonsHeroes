using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowHeroesSprite : MonoBehaviour
{
    public Image selectHeroSprite;
    public Text selectHeroName;
    public Text selectHeroBonus;
    public Text selectHeroMalus;
    public HeroesSelectionScript heroesSelectionScript;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        selectHeroName.text = "" + heroesSelectionScript.selectHero.heroName;
        selectHeroBonus.text = "" + heroesSelectionScript.selectHero.heroBonus;
        selectHeroMalus.text = "" + heroesSelectionScript.selectHero.heroMalus;
        selectHeroSprite.sprite =  heroesSelectionScript.selectHero.heroImage;
    }
}
