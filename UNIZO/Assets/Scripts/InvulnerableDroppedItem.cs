using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvulnerableDroppedItem : DroppedItem {

    public override void OnInteract(Actor actor){
        Player playerActor = (Player)actor;
        if (playerActor){
            playerActor.AddInvulnerablePoint();
        }
    }
}
