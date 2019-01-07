using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowResolution : MonoBehaviour
{

    // Use this for initialization
    void Update()
    {
            GetComponent<Text>().text = "" + Camera.main.pixelWidth + "x" + Camera.main.pixelHeight;
            Resolution[] resolutions = Screen.resolutions;
    }
}
