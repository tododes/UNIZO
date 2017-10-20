using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Interactable {

    public override void OnInteract(Actor actor)
    {
        Player playerActor = (Player)actor;
        if (playerActor){
            playerActor.startSwimming();
        }
    }

    public override void OnContinuouslyInteract(Actor actor)
    {
        Player playerActor = (Player)actor;
        if (playerActor){
            playerActor.staySwimming();
        }
    }

    public override void OnStopInteract(Actor actor)
    {
        Player playerActor = (Player)actor;
        if (playerActor){
            playerActor.stopSwimming();
        }
    }
}
