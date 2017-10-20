using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompanionSkillPanel : MonoBehaviour {

    private List<SkillView> skillViews;
    private Text companionTypeText;

    void Start(){
        skillViews = new List<SkillView>(transform.GetChild(0).GetComponentsInChildren<SkillView>());
        companionTypeText = transform.GetChild(1).GetComponent<Text>();
    }

    public void updateDisplay(string companionType, List<string> skills, List<int> levels){
        for(int i = 0; i < skillViews.Count; i++){
            skillViews[i].setSkillText(skills[i]);
            skillViews[i].updateLevel(levels[i]);
        }
    }

    public void Activate(bool b){
        gameObject.SetActive(b);
    }
}
