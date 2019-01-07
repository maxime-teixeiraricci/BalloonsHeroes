using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarBalloonShield : MonoBehaviour
{
    public TextMesh timerShow;
    public AudioClip starMusic;
    public double timeShield;
    public GameObject target;
    public double distance;
    public double speed;
    public float angle;
    public GameObject[] listOfShield;
    private double timer;
    float initSpeed;

	// Use this for initialization
	void Start ()
    {
        angle = 360f / (listOfShield.Length);
        angle = Mathf.Deg2Rad * angle;
        target = GameObject.Find("Player");
        GameObject.Find("Main").GetComponent<MainScript>().isInvinsible = true;
        initSpeed = GameObject.Find("Player").GetComponent<MoveScript>().speed;
        GameObject.Find("Main Camera").GetComponent<AudioSource>().clip = starMusic;
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
    }
	
	// Update is called once per frame
	void LateUpdate()
    {
        timerShow.text = ""+(int)timeShield;
        timerShow.gameObject.transform.position = target.transform.position + new Vector3(0,0,-1);
        GameObject.Find("Player").GetComponent<MoveScript>().speed *= 1.5f;
        timer += Time.deltaTime*speed;
        for (int i = 0; i < listOfShield.Length; i++)
        {
            Vector3 pos = new Vector3((float)(distance * Mathf.Cos((float)(angle * i + timer))), (float)(distance * Mathf.Sin((float)(angle * i + timer))), 0);
            listOfShield[i].transform.position = pos + target.transform.position;
        }
        timeShield -= Time.deltaTime;
        if (timeShield < 0)
        {
            GameObject.Find("Player").GetComponent<MoveScript>().speed = initSpeed;
            GameObject.Find("Main").GetComponent<MainScript>().isInvinsible = false;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().clip = GameObject.Find("Canvas").GetComponent<HUDManager>().gameMusic;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
	}

    public void CreateShield()
    {

    }
}
