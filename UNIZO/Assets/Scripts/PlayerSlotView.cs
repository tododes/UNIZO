using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlotView : MonoBehaviour, IViewer {

    private Image slotImage;
    [SerializeField] private ItemSpriteDatabase itemSpriteDB;
    [SerializeField] private Sprite defaultSprite;
    void Start(){
        slotImage = GetComponent<Image>();
    }

    public void updateItemDisplay(Item i){
        if (itemSpriteDB){
            if(i == null){
                slotImage.sprite = defaultSprite;
            }
            else{
                Sprite slotSprite = itemSpriteDB.getSpriteByItem(i);
                slotImage.sprite = slotSprite;
            }
            
        }
    }
}
