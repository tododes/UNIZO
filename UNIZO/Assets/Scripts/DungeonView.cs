using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonView : MonoBehaviour {

    [SerializeField] private List<DungeonLevelView> myLevelViews;
    [SerializeField] private List<Image> childImages;
    [SerializeField] private List<Text> childTexts;

    void Awake(){
        childImages = new List<Image>(GetComponentsInChildren<Image>());
        childTexts = new List<Text>(GetComponentsInChildren<Text>());
        setDisplay(null, false);
    }

    void Start(){
        myLevelViews = new List<DungeonLevelView>(GetComponentsInChildren<DungeonLevelView>());
       
    }

    public void setDisplay(Dungeon dungeon, bool b){
        if (b){
            for (int i = 0; i < myLevelViews.Count; i++){
                myLevelViews[i].UpdateView(dungeon.getLevelAtIndex(i));
            }
        }

        for (int i = 0; i < childImages.Count; i++){
            childImages[i].enabled = b;
        }

        for (int i = 0; i < childTexts.Count; i++){
            childTexts[i].enabled = b;
        }
    }
}
