using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class InterAd : MonoBehaviour
{
    private InterstitialAd interstitialAd;

    private string interstitialId = "ca-app-pub-4527310579010004/9677120792";
    // Start is called before the first frame update
    private void OnEnable()
    {
        interstitialAd = new InterstitialAd(interstitialId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(adRequest);
    }
    public void ShowAd()
    {
        if(interstitialAd.IsLoaded())
            interstitialAd.Show();
    }
}
