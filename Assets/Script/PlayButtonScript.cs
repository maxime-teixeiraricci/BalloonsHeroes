using UnityEngine;
using System.Collections;

public class PlayButtonScript : MonoBehaviour {
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        MainScript mainScript = GameObject.Find("Main").GetComponent<MainScript>();
        mainScript.numberGamesBeforeAdd -= 1;
        GameObject.Find("Main").GetComponent<MainScript>().gameStart = true;
        print("Test");
        //GameObject.Find("Main").GetComponent<MainScript>().numberGamesBeforeAdd -= 1;
        GameObject.Find("Main").GetComponent<MainScript>().InitializeGame();
        GameObject.Find("Canvas").GetComponent<HUDManager>().ActivateMenu(0);
        
    }
}
