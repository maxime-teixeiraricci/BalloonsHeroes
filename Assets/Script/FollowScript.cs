using UnityEngine;
using System.Collections;

public class FollowScript : MonoBehaviour
{
    public GameObject target;
    public Vector3 vect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.position = target.transform.position + vect;
	}
}
