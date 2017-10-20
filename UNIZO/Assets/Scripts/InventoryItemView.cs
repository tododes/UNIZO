using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour, IViewer {

    private const int ITEMIMAGE_CHILD_INDEX = 1;
    private const int ITEMTEXT_CHILD_INDEX = 0;
    [SerializeField]
    private Text itemText;
    [SerializeField]
    private Image itemImage;

    private List<Image> listImages;
    private List<Text> listTexts;

    [SerializeField] private ItemSpriteDatabase itemSpriteDB;

    private Item myItem;

    void Awake(){
        itemText = transform.GetChild(ITEMTEXT_CHILD_INDEX).GetComponent<Text>();
        itemImage = transform.GetChild(ITEMIMAGE_CHILD_INDEX).GetComponent<Image>();

        listImages = new List<Image>(GetComponentsInChildren<Image>());
        listTexts = new List<Text>(GetComponentsInChildren<Text>());
    }

    public void updateItemDisplay(Item i){
        if (i != null){
            myItem = i;
            itemText.text = i.name;
            if(itemSpriteDB)
                itemImage.sprite = itemSpriteDB.getSpriteByItem(i);
        }
        else { 
            Enable(false);
        }
    }

    public void Enable(bool b){
        bool bAndNotNull = (b && myItem != null);

        for (int i = 0; i < listImages.Count; i++){
            listImages[i].enabled = bAndNotNull;
        }

        for (int i = 0; i < listTexts.Count; i++){
            listTexts[i].enabled = bAndNotNull;
        }
    }

    public bool isItemNull() { return myItem == null; }
}
