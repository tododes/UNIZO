using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class RewardClaimPanel : AreYouSurePanel {

    [SerializeField] private Text rewardText;
    private StringBuilder sb = new StringBuilder();

    private void displayReward(Reward r){
        if(sb.Length > 0){
            sb.Remove(0, sb.Length);
        }
        sb.Append("You got");
        if (r.bonusCrystal > 0)
            sb.Append(r.bonusGold + " gold and \n" + r.bonusCrystal + " crystals");
        else
            sb.Append(r.bonusGold + " gold");
        rewardText.text = sb.ToString();
    }

    void FixedUpdate(){
        //Debug.Log(gameObject.name + " FixedUpdate " + Index);
    }

    protected override void Awake(){
        base.Awake();
        //Debug.Log(gameObject.name + " Awake " + Index);
    }

    void Start(){
        //Debug.Log(gameObject.name + " Start " + Index);
    }

    public void ClaimReward(Reward r){
        Debug.Log("Trigger");
        Trigger();
        displayReward(r);
    }
}
