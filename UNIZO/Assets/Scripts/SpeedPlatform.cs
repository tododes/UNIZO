using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPlatform : Interactable {

    [SerializeField] private float speedIncrease;

    public override void OnInteract(Actor actor){
        Player playerActor = (Player)actor;
        if (playerActor) {
            playerActor.ModifySpeed(speedIncrease);
        }
    }

    public override void OnStopInteract(Actor actor){
        Player playerActor = (Player)actor;
        if (playerActor) {
            playerActor.ModifySpeed(-speedIncrease);
        }
    }
}
