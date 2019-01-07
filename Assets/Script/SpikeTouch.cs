using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpikeTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        MainScript mainScript = GameObject.Find("Main").GetComponent<MainScript>();
        if (other.gameObject.tag == "Player")
        {
            if (!mainScript.isInvinsible)
            {
                if (mainScript.lives > 0)
                {
                    mainScript.lives -= 1;
                    Destroy(gameObject);
                }
                else
                {
                    if (mainScript.personalRecordScore < mainScript.score)
                    {
                        //mainScript.personalHeroRecordScore.sprite = mainScript.heroPlayer.heroImage;
                    }
                    mainScript.personalRecordMeters = Mathf.Max(mainScript.personalRecordMeters, mainScript.meters);
                    mainScript.personalRecordScore = (int)Mathf.Max(mainScript.personalRecordScore, mainScript.score);
                    mainScript.lastRecordMeters = mainScript.meters;
                    mainScript.coin += (int)((mainScript.score / 2000) + (mainScript.meters / 500));

                    mainScript.gameStart = false;
                    GameObject.Find("Main").GetComponent<MainScript>().Save();
                    GameObject.Find("Canvas").GetComponent<HUDManager>().ActivateMenu(2);
                }
            }
            else
            {
                Destroy(gameObject);
            }

            //SceneManager.LoadScene("Main");
        }
    }
}
