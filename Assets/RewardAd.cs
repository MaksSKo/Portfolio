using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class RewardAd : MonoBehaviour
{
    public GameManager GameManager;
    private RewardedAd rewardedAd;

    private string rewardedId = "ca-app-pub-4527310579010004/5382652569";
    // Start is called before the first frame update
    private void OnEnable()
    {
        rewardedAd = new RewardedAd(rewardedId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(adRequest);
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
    }

    private void HandleUserEarnedReward(object sender, Reward e)
    {
        GameManager.ContinueGame();
    }

    public void ShowAd()
    {
        if (rewardedAd.IsLoaded())
            rewardedAd.Show();
    }
}
