using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveScript : MonoBehaviour
{
    public MainScript mainScript;
    public float speed;
    public Text speeHUD;

    // Use this for initialization
    void Start()
    {
        mainScript = GameObject.Find("Main").GetComponent<MainScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerMove = (new Vector3(Input.GetAxis("Horizontal"), 0, 0) + new Vector3(Input.acceleration.x, 0, 0)) * 0.5f;

        float speedSub1 = mainScript.numberBalloons *0.05f + 2f;
        float speedSub2 = mainScript.score / 10000f;

        float speedSubInvincible = (mainScript.isInvinsible)? 7 : 0;

        speed = (speedSub1 + speedSub2) + speedSubInvincible;
        if (mainScript.gameStart)
        {
            transform.position += playerMove + new Vector3(0, Time.deltaTime * speed, 0);
            transform.position = new Vector3(Mathf.Max(-2.75f, Mathf.Min(2.75f, transform.position.x)), transform.position.y, transform.position.z);
        }
    }
}
