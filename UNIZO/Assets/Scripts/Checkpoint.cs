using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : Interactable {

    [SerializeField]
    private CheckpointText myText;

    public override void OnInteract(Actor actor){
        if(actor is Player){
            myText.Trigger();
            Player playerActor = (Player)actor;
            playerActor.setLastVisitedCheckpoint(this);
        }
    }
}
