using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompanionSkillLoader : MonoBehaviour {

    private List<string> skills = new List<string>();
    private List<Image> skillImages = new List<Image>();

    [SerializeField]
    private PlayerSaveData currentSaveData;

    [SerializeField] private NameToSkillSpriteDatabase nameSpriteDB;
	// Use this for initialization
	void Start () {
        currentSaveData = Player.singleton.getCurrentSaveData();
        CompanionData companionData = currentSaveData.getCompanionData();
        for(int i = 0; i < companionData.mySkills.Count; i++){
            skills.Add(companionData.mySkills[i]);
        }
        skillImages = new List<Image>(GetComponentsInChildren<Image>());

        for(int i = 0; i < skills.Count; i++){
            skillImages[i].sprite = nameSpriteDB.getSpriteByName(skills[i]);
        }
	}
}
