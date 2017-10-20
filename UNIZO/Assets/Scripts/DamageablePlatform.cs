using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageablePlatform : Actor {

    void OnTriggerEnter(Collider coll){
        Interactable interactedObj = coll.GetComponent<Interactable>();
        if (interactedObj){
            interactedObj.OnInteract(this);
        }
    }
}
