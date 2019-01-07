using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BalloonCollect : MonoBehaviour
{

    public AudioClip[] sound;
    public AudioSource source;
    public int value;

    // Use this for initialization
    void Start()
    {
        source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnCollisionEnter2D(Collision2D coll)
    {
            print(coll);
            if (coll.gameObject.tag == "player")
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
                Destroy(gameObject);
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("Main").GetComponent<MainScript>().numberBalloons += value;
            if (GameObject.Find("BalloonCount").GetComponent<Image>().color == GetComponent<SpriteRenderer>().color)
            {
                GameObject.Find("Main").GetComponent<MainScript>().combo += value;
            }
            else
            {
                GameObject.Find("BalloonCount").GetComponent<Image>().color = GetComponent<SpriteRenderer>().color;
                GameObject.Find("Main").GetComponent<MainScript>().combo = value;
            }

            source.PlayOneShot(sound[Random.Range(0,sound.Length)],0.5f);
            GameObject.Find("Main").GetComponent<MainScript>().score += 5 * value*(float)GameObject.Find("Main").GetComponent<MainScript>().coefCombo * GameObject.Find("Main").GetComponent<MainScript>().heroPlayer.heroStat.scoreMult;
            Destroy(gameObject);
        }
    }
}
