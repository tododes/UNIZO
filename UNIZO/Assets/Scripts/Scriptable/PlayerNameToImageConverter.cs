using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNameToImageConverter : ScriptableObject {

    [SerializeField]
    private List<string> playerNames;

    [SerializeField]
    private List<Sprite> playerSprites;

    public Sprite convert(string n){
        int index = playerNames.IndexOf(n);
        if (playerNames.Count == 0 || index == -1 || index >= playerNames.Count)
            return null;

        return playerSprites[index];
    }
}
