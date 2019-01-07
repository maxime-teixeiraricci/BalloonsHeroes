using UnityEngine;
using System.Collections;

public class ImageShadow : MonoBehaviour
{
    public Vector3 vect;

	// Use this for initialization
	void Start ()
    {
        GameObject shadowObject = new GameObject();
        shadowObject.transform.localScale *= transform.lossyScale.x;
        Destroy(shadowObject.GetComponent<ImageShadow>());
        shadowObject.AddComponent<SpriteRenderer>();
        shadowObject.name = "Shadow " + gameObject.name;
        shadowObject.transform.parent = gameObject.transform;
        shadowObject.transform.position = vect + transform.position;
        shadowObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.3f);
        shadowObject.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
