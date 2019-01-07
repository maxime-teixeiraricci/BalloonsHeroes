using UnityEngine;
using System.Collections;

public class CoinCollect : MonoBehaviour
{
    public int value;
    public Color[] colorValue;
    public AudioClip sound;
    public AudioSource source;
    // Use this for initialization
    void Start ()
    {
        source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        int R = Random.Range(0, 10);
        if (R <= 5)
        {
            value = 1;
            GetComponent<SpriteRenderer>().color = colorValue[0];
        }
        else if (R <= 8)
        {
            value = 5;
            GetComponent<SpriteRenderer>().color = colorValue[1];
        }
        else
        {
            value = 10;
            GetComponent<SpriteRenderer>().color = colorValue[2];
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("Main").GetComponent<MainScript>().coin += value;
            source.PlayOneShot(sound, 0.5f);
            GameObject.Find("Main").GetComponent<MainScript>().score += 2 * value * (float) GameObject.Find("Main").GetComponent<MainScript>().coefCombo;
            Destroy(gameObject);
        }
    }

}

