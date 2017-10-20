using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpgrader : MonoBehaviour {

    [SerializeField] private int index;
    private Button button;
    private TreeController treeController;

	void Start () {
        treeController = TreeController.singleton;
        button = GetComponent<Button>();
        button.onClick.AddListener(Upgrade);
        string parentName = transform.parent.name;
        char parentIndexCode = parentName[parentName.Length - 1];
        index = ((int)parentIndexCode - '0') - 1;
	}
	
	void Update () {
		
	}

    public void Upgrade(){
        treeController.getCurrentSaveData().upgradeCompanionSkill(index);
        treeController.updateSkillPanelDisplay();
    }
}
