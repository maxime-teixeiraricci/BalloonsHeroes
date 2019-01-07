using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinShow : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Text>().text = ""+ GameObject.Find("Main").GetComponent<MainScript>().coin;
	}
}
