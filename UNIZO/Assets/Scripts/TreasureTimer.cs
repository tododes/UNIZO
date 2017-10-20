using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.UI;

public class TreasureTimer : MonoBehaviour {

    private Clock lastClaimTime;
    private DateTime lastLoginDate;
    [SerializeField] private int elapsedMinuteRequired;
    [SerializeField] private string savePath;
    [SerializeField] private Reward treasureReward;
    [SerializeField] private BagSceneController bagController;
    [SerializeField] private Text treasureTimerDisplayer;
    [SerializeField] private RewardClaimPanel claimPanel;
    [SerializeField] private WaitForSeconds OneSecondDelay = new WaitForSeconds(1);
    //[SerializeField] private bool initTreasure;
    [SerializeField] private bool treasureShouldBeOpen;

    private StringBuilder sb;

    void Awake() { bagController = BagSceneController.singleton; }
	// Use this for initialization
	void Start () {
        sb = new StringBuilder();
        bagController = BagSceneController.singleton;
        StartCoroutine(UpdateText());
        StartCoroutine(treasureReadyCheck());
        //checkIfItsTimeToClaim();
        //StartCoroutine(UpdateText());
    }

    private IEnumerator treasureReadyCheck(){
        yield return new WaitForSeconds(1);
        checkIfItsTimeToClaim();
        StartCoroutine(UpdateText());
    }

    // Update is called once per frame
    private IEnumerator UpdateText () {
        TimeSpan nextLoginTimeFromNow = DateTime.Now.AddHours(1).Subtract(DateTime.Now);
        while (true){
            if(nextLoginTimeFromNow.TotalSeconds >= 0){
                DateTime nextLoginTime = lastLoginDate.AddMinutes(elapsedMinuteRequired);
                DateTime now = DateTime.Now;
                nextLoginTimeFromNow = nextLoginTime.Subtract(now);
            }
            MakeTimespanText(nextLoginTimeFromNow);
            yield return OneSecondDelay;
        }
        
	}

    private void MakeTimespanText(TimeSpan ts){
        if(sb.Length > 0)
            sb.Remove(0, sb.Length);
        sb.Append(ts.Hours);
        sb.Append(" : ");
        sb.Append(ts.Minutes);
        sb.Append(" : ");
        sb.Append(ts.Seconds);
        treasureTimerDisplayer.text = sb.ToString();
    }

    private void checkIfItsTimeToClaim(){
        if (GameStorage.Exists(Application.persistentDataPath + savePath)){
            lastClaimTime = GameStorage.Load<Clock>(Application.persistentDataPath + savePath);
            lastLoginDate = lastClaimTime.convertToDateTime();
            DateTime rightNow = DateTime.Now;
            TimeSpan lastLoginUntilNow = rightNow.Subtract(lastLoginDate);

            if (lastLoginUntilNow.Minutes >= elapsedMinuteRequired){
                treasureShouldBeOpen = true;
                PlayerSaveData psd = bagController.getCurrentSaveData();
                psd.ClaimReward(treasureReward);
                lastClaimTime.SetDataFromDateTime(rightNow);
                lastLoginDate = lastClaimTime.convertToDateTime();
                GameStorage.Save<Clock>(lastClaimTime, Application.persistentDataPath + savePath);
            }
        }
        else{
            lastLoginDate = DateTime.Now;
            lastClaimTime = new Clock(Application.persistentDataPath + savePath, lastLoginDate);
            GameStorage.Save<Clock>(lastClaimTime, Application.persistentDataPath + savePath);
        }
    }

    void Update(){

        if (treasureShouldBeOpen){
            claimPanel.ClaimReward(treasureReward);
            treasureShouldBeOpen = false;
        }
    }
}
