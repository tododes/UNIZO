using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MenuController {

    public static ShopManager singleton { get; private set; }
    private ShopView myView;
  
    void Awake(){
        singleton = this;
    }

    // Use this for initialization
    protected override void Start() {
        myView = ShopView.singleton;
        base.Start();
        if(currentSaveData != null)
            myView.UpdateView(currentSaveData);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BuyItem(Item item){
        if(currentSaveData.getGold() >= item.price){
            currentSaveData.modifyGold(-item.price);
            currentSaveData.AddSavedItem(item);
            myView.UpdateView(currentSaveData);
        }
    }

    public override void SaveGameData()
    {
        base.SaveGameData();
    }
}
