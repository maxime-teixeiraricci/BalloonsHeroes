using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowSpeed : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float speed = GameObject.Find("Player").GetComponent<MoveScript>().speed;
        speed = (int)(speed * 100);
        speed /= 100f;
        GetComponent<Text>().text = "Speed : " + speed;
    }
}
