using UnityEngine;
using System.Collections;

public class MapRandom : MonoBehaviour
{
    public GameObject balloonObject;
    public GameObject balloon2Object;
    public GameObject balloon5Object;
    public GameObject balloon10Object;
    public GameObject spikeObject;
    public GameObject balloonHeartObject;
    public GameObject balloonStarObject;
    public GameObject[] cloudsObject;
    public GameObject coinObject;
    public HeroesSelectionScript heroesSelectionScript;

    [Range(0f, 100f)]
    public float pbFill;
    [Range(0f, 100f)]
    public float pbBalloon;
    [Range(0f, 100f)]
    public float pbBalloon2;
    [Range(0f, 100f)]
    public float pbBalloon5;
    [Range(0f, 100f)]
    public float pbBalloon10;
    [Range(0f, 100f)]
    public float pbBalloonHeart;
    [Range(0f, 100f)]
    public float pbBalloonStar;
    [Range(0f, 100f)]
    public float pbSpike;
    [Range(0f, 100f)]
    public float pbCloud;
    [Range(0f, 100f)]
    public float pbCoin;

    public float mapLimitCreate;
    public float currentCreate;
    Vector3 lastSpike;


    Transform player;

    // Use this for initialization
    void Start ()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        //MapCreate();
        player = GameObject.Find("Player").transform;
        mapLimitCreate = ((int)((4.0f + player.position.y) * 2.0f)) / 2.0f; ;
        currentCreate = 12.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        mapLimitCreate = ((int)((15.0f + player.position.y) * 2.0f)) / 2.0f; ;
        if (currentCreate < mapLimitCreate)
        {
            CreateItem(new Vector3(0, currentCreate, 0));
            currentCreate += Random.Range(0.25f,1.25f);
        }

        
    }

    void CreateItem(Vector3 pos)
    {
        MainScript mainScript = GameObject.Find("Main").GetComponent<MainScript>();
        float realPbBalloon = pbBalloon * mainScript.heroPlayer.heroStat.probBalloonsModify;
        float realPbBalloon2 = pbBalloon2 * mainScript.heroPlayer.heroStat.probBalloons2Modify;
        float realPbBalloon5 = pbBalloon5 * mainScript.heroPlayer.heroStat.probBalloons5Modify;
        float realPbBalloon10 = pbBalloon10 * mainScript.heroPlayer.heroStat.probBalloons10Modify;
        float realPbBalloonHeart = pbBalloonHeart * mainScript.heroPlayer.heroStat.probHeartBalloonsModify;
        float realPbSpike = pbSpike * mainScript.heroPlayer.heroStat.probSpikeModify;
        float realPbCloud = pbCloud * mainScript.heroPlayer.heroStat.probCloudsModify;
        float realPbCoin = pbCoin * mainScript.heroPlayer.heroStat.probCoinsModify;
        float realPbStarBalloon = pbBalloonStar * mainScript.heroPlayer.heroStat.probStarBalloonsModify;
        if (Random.Range(0f,100f) < pbFill)
        {
            int total = (int)((realPbBalloon + realPbCloud + realPbSpike + realPbCoin + realPbBalloonHeart + realPbStarBalloon) * 1.5);
            Vector3 posItem = new Vector3(Random.Range(-3f, 3f), 0, 0) + pos;
            float R = Random.Range(0, total);

            if (R <= realPbSpike)
            {

                Vector3 spikePos = new Vector3(Random.Range(-3f, 3f), 0, 0) + pos;
                while (Vector3.Distance(spikePos, lastSpike) < 3 && Vector3.Distance(spikePos, lastSpike) > 1)
                {
                    spikePos = new Vector3(Random.Range(-3f, 3f), 0, 0) + pos;
                }
                lastSpike = spikePos;
                Instantiate(spikeObject, spikePos, Quaternion.identity);

            }
            else if ( R <= realPbSpike + realPbBalloon) 
            {
                float R2 = Random.Range(0, (realPbBalloon+realPbBalloon2 + realPbBalloon5 + realPbBalloon10));
                if (R2 < realPbBalloon2)
                {
                    GameObject balloon = (GameObject)Instantiate(balloon2Object, posItem, Quaternion.identity);
                    balloon.transform.position += new Vector3(0, 0, -5);
                }
                else if (R2 < realPbBalloon2 + realPbBalloon5)
                {
                    GameObject balloon = (GameObject)Instantiate(balloon5Object, posItem, Quaternion.identity);
                    balloon.transform.position += new Vector3(0, 0, -5);
                }
                else if (R2 < realPbBalloon2 + realPbBalloon5 + realPbBalloon10)
                {
                    GameObject balloon = (GameObject)Instantiate(balloon10Object, posItem, Quaternion.identity);
                    balloon.transform.position += new Vector3(0, 0, -5);
                }
                else
                {
                    GameObject balloon = (GameObject)Instantiate(balloonObject, posItem, Quaternion.identity);
                    balloon.transform.position += new Vector3(0, 0, -5);
                }
            }
            else if (R <= realPbBalloon + realPbCloud + realPbSpike)
            {
                GameObject cloud = (GameObject) Instantiate(cloudsObject[Random.Range(0,cloudsObject.Length)], posItem, Quaternion.identity);
                cloud.transform.position += new Vector3(0, 0, -7);
            }
            else if (R <= realPbBalloon + realPbCloud + realPbSpike + realPbCoin)
            {
                GameObject coin = (GameObject)Instantiate(coinObject, posItem, Quaternion.identity);
                coin.transform.position += new Vector3(0, 0, -5);
            }
            else if (R <= realPbBalloon + realPbCloud + realPbSpike + realPbCoin + realPbBalloonHeart)
            {
                GameObject heartBallon = (GameObject)Instantiate(balloonHeartObject, posItem, Quaternion.identity);
                heartBallon.transform.position += new Vector3(0, 0, -5);
            }
            else if (R <= realPbBalloon + realPbCloud + realPbSpike + realPbCoin + realPbBalloonHeart)
            {
                GameObject heartBallon = (GameObject)Instantiate(balloonHeartObject, posItem, Quaternion.identity);
                heartBallon.transform.position += new Vector3(0, 0, -5);
            }
            else if (R <= realPbBalloon + realPbCloud + realPbSpike + realPbCoin + realPbBalloonHeart + realPbStarBalloon)
            {
                GameObject starBallon = (GameObject)Instantiate(balloonStarObject, posItem, Quaternion.identity);
                starBallon.transform.position += new Vector3(0, 0, -5);
            }
        }
    }
    void MapCreate()
    {
        for(float y = 0; y < 2000; y ++)
        {
            CreateItem(new Vector3(0, y, 0));
        }
    }
}

