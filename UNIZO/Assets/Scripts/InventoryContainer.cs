using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryContainer : MonoBehaviour {

    private List<InventoryItemView> itemViews;
    private Text noItemText; 

	// Use this for initialization
	void Start () {
        itemViews = new List<InventoryItemView>(GetComponentsInChildren<InventoryItemView>());
        noItemText = transform.FindChild("No Item").GetComponent<Text>();
	}
	
    public void EnableInventoryView(bool b){
        for(int i = 0; i < itemViews.Count; i++){
            itemViews[i].Enable(b);
        }
    }

    private bool isAllItemNull(){
        for(int i = 0; i < itemViews.Count; i++){
            if (!itemViews[i].isItemNull())
                return false;
        }
        return true;
    }

    public void validateNoItemText(){
        noItemText.enabled = isAllItemNull();
    }
}
