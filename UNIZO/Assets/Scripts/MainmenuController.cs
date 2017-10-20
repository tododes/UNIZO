using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainmenuController : MenuController {

    public static MainmenuController singleton { get; private set; }

    // Use this for initialization
    private Clock lastLoginTime;

   
    [SerializeField] private List<Reward> streakRewards = new List<Reward>();

    void Awake(){
        singleton = this;
    }

	protected override void Start () {
        base.Start();
        if (GameStorage.Exists(Application.persistentDataPath + SaveKey.LOGINTIME_KEY)){
            lastLoginTime = GameStorage.Load<Clock>(Application.persistentDataPath + SaveKey.LOGINTIME_KEY);
            DateTime lastLoginDate = lastLoginTime.convertToDateTime();
            DateTime rightNow = DateTime.Now;
            TimeSpan lastLoginUntilNow = rightNow.Subtract(lastLoginDate);
            if(lastLoginUntilNow.Days >= 1){
                if(lastLoginUntilNow.Days > 1) {
                    currentSaveData.ResetStreak();
                    currentSaveData.ClaimReward(streakRewards[currentSaveData.getLoginStreak()]);
                    //reset reward
                    //get reward
                }
                else {
                    currentSaveData.ClaimReward(streakRewards[currentSaveData.getLoginStreak()]);
                    currentSaveData.AddStreak();
                    //get reward
                    //reward increment
                }
                lastLoginTime.SetDataFromDateTime(rightNow);
                GameStorage.Save<Clock>(lastLoginTime, Application.persistentDataPath + SaveKey.LOGINTIME_KEY);
            }
        }
        else{
            lastLoginTime = new Clock(Application.persistentDataPath + SaveKey.LOGINTIME_KEY, DateTime.Now);
            //baru main
        }

       
	}

    public override void SaveGameData(){
        base.SaveGameData();
        Debug.Log("Main menu data");
    }

    // Update is called once per frame
    void Update () {
		
	}

  
}
