﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageMenuController : MenuController {

	// Use this for initialization
	protected override void Start () {
        base.Start();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void SaveGameData()
    {
        base.SaveGameData();
        Debug.Log("Village menu data");
    }
}