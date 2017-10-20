using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Interactable{

    public override void OnInteract(Actor actor){
        actor.receiveDamage();
    }
}
