using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolinePlatform : Interactable {

    public override void OnInteract(Actor actor){
        Debug.Log(actor);
        actor.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 750f);
    }
}
