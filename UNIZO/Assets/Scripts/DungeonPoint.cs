using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPoint : MonoBehaviour {

    [SerializeField] private Dungeon dungeon;
    [SerializeField] private DungeonSelectionSceneController dungeonSelectionController;

    void Start(){
        dungeonSelectionController = DungeonSelectionSceneController.singleton;
    }

    public Dungeon getDungeon() { return dungeon; }

    void OnMouseDown(){
        dungeonSelectionController.EnableDungeonView(dungeon);
    }
}
