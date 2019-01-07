using UnityEngine;
using System.Collections;

public class ColorRandomizer : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        Color[] listColor = GameObject.Find("Main").GetComponent<MainScript>().heroPlayer.heroStat.balloonsColorList;
        GetComponent<SpriteRenderer>().color = listColor[Random.Range(0, listColor.Length)];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
