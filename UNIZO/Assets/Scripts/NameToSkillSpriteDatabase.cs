using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameToSkillSpriteDatabase : ScriptableObject {

    [SerializeField]
    private List<string> skillNames;

    [SerializeField]
    private List<Sprite> skillSprites;

    public Sprite getSpriteByName(string n){
        return skillSprites[skillNames.IndexOf(n)];
    }
}
