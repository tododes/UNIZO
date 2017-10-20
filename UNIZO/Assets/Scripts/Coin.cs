using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Interactable {

    [SerializeField] private int amount;

    public override void OnInteract(Actor actor){
        Player playerActor = (Player) actor;
        if (playerActor){
            playerActor.ModifyGoldAndCrystal(amount, 0);
            base.OnInteract(actor);
        }
    }
}
