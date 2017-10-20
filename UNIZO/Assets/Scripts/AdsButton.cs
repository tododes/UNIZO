using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsButton : Button {

    private int coin;
	// Use this for initialization
	new void Start () {
        base.Start();
        coin = 0;
        GetComponentInChildren<Text>().text = coin.ToString();
        onClick.AddListener(showAd);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showAd(){
        if (Advertisement.IsReady()){
            Advertisement.Show("rewardedVideo", new ShowOptions() {
                resultCallback = setResult
            });
        }
    }

    public void setResult(ShowResult sr){
        switch (sr){
            case ShowResult.Finished:
                coin += 10;
                GetComponentInChildren<Text>().text = coin.ToString();
                break;
            case ShowResult.Failed:

                break;
            case ShowResult.Skipped:

                break;
        }
    }
}
