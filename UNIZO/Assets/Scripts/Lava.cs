using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : Interactable {

    public override void OnInteract(Actor actor){
        Player playerActor = (Player)actor;
        if (playerActor){
            playerActor.instantDead();
        }
    }
}
