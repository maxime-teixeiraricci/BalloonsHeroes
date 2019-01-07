using UnityEngine;
using System.Collections;

public class FacebookPage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FaceBook()
    {
        Application.OpenURL("https://www.facebook.com/balloons.heroes");
    }
}
