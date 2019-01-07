using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ReturnMenu()
    {
        GameObject.Find("Canvas").GetComponent<HUDManager>().ActivateMenu(1);
        GameObject.Find("Main").GetComponent<MainScript>().gameStart = false;
        GameObject.Find("Main").GetComponent<MainScript>().Save();
        GameObject.Find("Main").GetComponent<MainScript>().InitializeGame();
    }
}
