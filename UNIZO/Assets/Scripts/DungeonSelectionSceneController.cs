using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSelectionSceneController : MenuController {

    public static DungeonSelectionSceneController singleton { get; private set; }
    private Dictionary<Dungeon, DungeonView> dungeonToDungeonView = new Dictionary<Dungeon, DungeonView>();
    private DungeonView currentlyDisplayedDungeonView;

    [SerializeField]
    private Canvas dungeonViewCanvas;

    void Awake(){
        singleton = this;
    }

    protected override void Start(){
        base.Start();
        DungeonView[] dungeonViews = FindObjectsOfType<DungeonView>();
        DungeonPoint[] dungeonPoints = FindObjectsOfType<DungeonPoint>();

        MonoSorter<DungeonView>.Sort(dungeonViews);
        MonoSorter<DungeonPoint>.Sort(dungeonPoints);

        for (int i = 0; i < dungeonViews.Length; i++){
            dungeonToDungeonView.Add(dungeonPoints[i].getDungeon(), dungeonViews[i]);
        }
        dungeonViewCanvas = GameObject.Find("Dungeon View").GetComponent<Canvas>();
    }

    public void EnableDungeonView(Dungeon d){
        if(currentlyDisplayedDungeonView)
            currentlyDisplayedDungeonView.setDisplay(null, false);

        currentlyDisplayedDungeonView = dungeonToDungeonView[d];
        dungeonViewCanvas.enabled = true;
        currentlyDisplayedDungeonView.setDisplay(d, true);
    }
}
