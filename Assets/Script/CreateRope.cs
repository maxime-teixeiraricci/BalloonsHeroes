using UnityEngine;
using System.Collections;

public class CreateRope : MonoBehaviour
{
    public GameObject baloon;
    public GameObject ropeObject;

    // Use this for initialization
    void Start ()
    {
        RopeCreate();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void RopeCreate()
    {
        Vector3 posRope = (transform.position + baloon.transform.position ) * 0.5f + new Vector3(0,0,0.05f);
        float angle = Vector3.Angle(new Vector3(0, 1, 0), baloon.transform.position - transform.position);
        GameObject rope = (GameObject)Instantiate(ropeObject, posRope, Quaternion.identity);
        rope.transform.name = "Real Rope";
        rope.transform.localScale = new Vector3(1, Vector3.Distance(transform.position, baloon.transform.position),1);
        rope.transform.Rotate(new Vector3(0, 0, 1), angle);
    }
}
