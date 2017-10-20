using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpriteDatabase : ScriptableObject {

    [SerializeField] private List<Item> items;
    [SerializeField] private List<Sprite> itemSprites;

    public Sprite getSpriteByItem(Item i){
        return itemSprites[items.IndexOf(i)];
    }

    public Item getItemBySprite(Sprite s){
        return items[itemSprites.IndexOf(s)];
    }

    public Sprite getSpriteByItemName(string search){
        int index = 0;
        for(int i = 0; i < items.Count; i++){
            if(items[i].name == search){
                index = i;
                break;
            }
        }
        return itemSprites[index];
    }
}
