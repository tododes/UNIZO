using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillView : MonoBehaviour {

    private Text skillText;
    private List<Image> skillLevelImages;

    void Start(){
        skillText = transform.GetChild(0).GetComponent<Text>();
        Image[] levelImages = GetComponentsInChildren<Image>();
        MonoSorter<Image>.Sort(levelImages);
        skillLevelImages = new List<Image>(levelImages);
    }

    public void setSkillText(string t){
        skillText.text = t;
    }

    public void updateLevel(int level){
        for(int i = 0; i < level; i++){
            skillLevelImages[i].enabled = true;
        }
        for (int i = level; i < 10; i++){
            skillLevelImages[i].enabled = false;
        }
    }
}
