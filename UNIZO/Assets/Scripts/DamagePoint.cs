using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePoint : Interactable {

    private Actor myActor;

    void Start(){
        myActor = GetComponentInParent<Actor>();
    }

    public override void OnInteract(Actor actor){
        Debug.Log(actor.name);
        Player playerActor = (Player)actor;
        
        if (playerActor){
            Debug.Log("Yes");
            myActor.instantDead();
            myActor.gameObject.SetActive(false);
        }
    }
}
