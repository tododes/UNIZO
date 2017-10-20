using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;

public class CompanionTypeSelectionPanel : AreYouSurePanel {

    private Dictionary<string, List<string>> typeToSkillList = new Dictionary<string, List<string>>();
    private List<string> skills;
    [SerializeField] private MenuController controller;
    [SerializeField] private PlayerSaveData saveData;

    private delegate void SelectCompanionType();
    private SelectCompanionType selectCompanionType;

    void Start(){
        base.Awake();
        typeToSkillList.Add("Spreading Shoot", new List<string>(new string[] { "Spread", "Boom" , "Firing" }));
        typeToSkillList.Add("Piercing Shoot", new List<string>(new string[] { "Rapid", "Faster", "Circle Fire" }));
        controller = GameObject.Find("Menu Controller").GetComponent<MenuController>();
    }

    public void SelectType(string buttonName){
        saveData = controller.getCurrentSaveData();
        skills = typeToSkillList[buttonName];
        for(int i = 0; i < skills.Count; i++){
            saveData.getCompanionData().AddSkill(skills[i]);
            saveData.getCompanionData().AddSkillLevel(1);
        }
        controller.setCurrentSaveData(saveData);
    }
}
