using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeartBalloonCollect : MonoBehaviour
{
    public AudioClip sound;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("Main").GetComponent<MainScript>().numberBalloons += 1;
            GameObject.Find("Main").GetComponent<MainScript>().lives = 1;
            if (GameObject.Find("BalloonCount").GetComponent<Image>().color == GetComponent<SpriteRenderer>().color)
            {
                GameObject.Find("Main").GetComponent<MainScript>().combo += 1;
            }
            else
            {
                GameObject.Find("BalloonCount").GetComponent<Image>().color = GetComponent<SpriteRenderer>().color;
                GameObject.Find("Main").GetComponent<MainScript>().combo = 1;
            }
            GameObject.Find("Main").GetComponent<MainScript>().score += 5 * (float)GameObject.Find("Main").GetComponent<MainScript>().coefCombo;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(sound, 0.5f);
            Destroy(gameObject);
        }
    }
}
