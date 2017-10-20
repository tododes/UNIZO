using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : Button {

    private Item myItem;
 
    new void Start(){
        base.Start();
        onClick.AddListener(EquipOrRemoveItem);
    }

    private void EquipOrRemoveItem(){
        BagSceneController bsc = BagSceneController.singleton;
        bsc.UpdatePlayerEquippedItem(myItem);
    }

    public void setMyItem(Item i) { myItem = i; }
}
