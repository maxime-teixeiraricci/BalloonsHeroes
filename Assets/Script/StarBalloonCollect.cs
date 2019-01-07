using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarBalloonCollect : MonoBehaviour
{
    public AudioClip sound;
    public GameObject balloonShield;

    void Start()
    {

    }
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("Main").GetComponent<MainScript>().numberBalloons += 1;

            if (GameObject.Find("BalloonCount").GetComponent<Image>().color == GetComponent<SpriteRenderer>().color)
            {
                GameObject.Find("Main").GetComponent<MainScript>().combo += 1;
            }
            else
            {
                GameObject.Find("BalloonCount").GetComponent<Image>().color = GetComponent<SpriteRenderer>().color;
                GameObject.Find("Main").GetComponent<MainScript>().combo = 1;
            }

            GameObject.Find("Main").GetComponent<MainScript>().score += 10 * (float)GameObject.Find("Main").GetComponent<MainScript>().coefCombo;
            if (!GameObject.Find("Main").GetComponent<MainScript>().isInvinsible)
            {
                print("OK");
                Instantiate(balloonShield);
            }
            else
            {
                GameObject.Find("StarBalloonShield(Clone)").GetComponent<StarBalloonShield>().timeShield = 5;
            }

            Destroy(gameObject);
        }
    }
}
