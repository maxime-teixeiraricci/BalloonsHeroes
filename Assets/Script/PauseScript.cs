using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PauseGame()
    {
        print("Pause");
        Time.timeScale = 0f;
        GameObject.Find("Main").GetComponent<MainScript>().gameStart = false;
        GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0.35f;
        GameObject.Find("Canvas").GetComponent<HUDManager>().ActivateMenu(4);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        GameObject.Find("Main").GetComponent<MainScript>().gameStart = true;
        GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 1f;
        GameObject.Find("Canvas").GetComponent<HUDManager>().ActivateMenu(0);
    }
}
