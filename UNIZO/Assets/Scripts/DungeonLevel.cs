using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DungeonLevel {

    [SerializeField]
    private string name;
    [SerializeField]
    private int difficultyLevel;

    public int getDifficulty()
    {
        return difficultyLevel;
    }

    public string getName()
    {
        return name;
    }
}
