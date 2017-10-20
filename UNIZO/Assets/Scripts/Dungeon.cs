using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dungeon {

    [SerializeField]
    private string Name;

    [SerializeField]
    private List<DungeonLevel> levels = new List<DungeonLevel>();

    public string getName() { return Name; }
    public int getLevelCount() { return levels.Count; }
    public DungeonLevel getLevelAtIndex(int index){
        return levels[index];
    }
} 
