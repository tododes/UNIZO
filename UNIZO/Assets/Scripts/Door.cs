using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable {

    private Level currentGameLevel;
    private Player currentPlayer;

    public override void OnInteract(Actor actor){
        if (!currentGameLevel)
            currentGameLevel = Level.singleton;
        currentPlayer = (Player) actor;
        currentGameLevel.Accomplish();
    }

    public override void OnContinuouslyInteract(Actor actor){
        
    }
}
