﻿using UnityEngine;
#if UNITY_ADS
using UnityEngine.Advertisements; // only compile Ads code on supported platforms
#endif

public class UnityAdsExampleBis : MonoBehaviour
{
    public AudioSource source;

    public void ShowDefaultAd()
    {
#if UNITY_ADS
        if (!Advertisement.IsReady())
        {
            Debug.Log("Ads not ready for default zone");
            return;
        }

        Advertisement.Show();
#endif
    }

    public void ShowRewardedAd()
    {
        const string RewardedZoneId = "adsInterlude";

#if UNITY_ADS
        if (!Advertisement.IsReady(RewardedZoneId))
        {
            Debug.Log(string.Format("Ads not ready for zone '{0}'", RewardedZoneId));
            return;
        }

        var options = new ShowOptions { resultCallback = HandleShowResult };
        Advertisement.Show(RewardedZoneId, options);
#endif
    }

#if UNITY_ADS
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //GameObject.Find("Main").GetComponent<MainScript>().coin += 100;
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
#endif

    void Update()
    {
        MainScript mainScript = GameObject.Find("Main").GetComponent<MainScript>();
        if (mainScript.numberGamesBeforeAdd == 0)
        {
            const string RewardedZoneId = "adsInterlude";
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(RewardedZoneId, options);
            
            mainScript.numberGamesBeforeAdd = Random.Range(5, 9);
        }
        if (Advertisement.isShowing)
        {
            source.Stop();
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
    }
}