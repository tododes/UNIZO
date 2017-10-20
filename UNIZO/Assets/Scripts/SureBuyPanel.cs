using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SureBuyPanel : AreYouSurePanel {

    public Item containedItem;

    public override void Yes(string name){
        ShopManager.singleton.BuyItem(containedItem);
    }

    public void Trigger(Item item){
        containedItem = item;
        Trigger();
    }
}
