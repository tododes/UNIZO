using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDroppedItem : DroppedItem {

    public override void OnInteract(Actor actor){
        Player playerActor = (Player)actor;
        if (playerActor){
            playerActor.AddHealth();
        }
        base.OnInteract(actor);
    }
}
