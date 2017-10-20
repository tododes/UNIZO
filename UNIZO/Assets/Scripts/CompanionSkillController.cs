using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CompanionSkillController : MonoBehaviour {

    private Dictionary<string, Action> skillNameToCompanionAction = new Dictionary<string, Action>();
	// Use this for initialization
	void Start () {
        //string skillName = GameStorage.Load<string>(Application.persistentDataPath + SaveKey.COMPANIONSKILLNAME_KEY);
        //Action choosedAction = skillNameToCompanionAction[skillName];
        //choosedAction.Invoke();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
