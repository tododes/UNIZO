using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public virtual void OnInteract(Actor actor){
        gameObject.SetActive(false);
    }

    public virtual void OnContinuouslyInteract(Actor actor){

    }

    public virtual void OnStopInteract(Actor actor){

    }
}
