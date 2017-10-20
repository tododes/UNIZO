using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Interactable {

    private Vector3 desiredPosition, originalPosition;
    private float timer;

    void Start(){
        desiredPosition = transform.position;
        originalPosition = transform.position;
    }

    public override void OnInteract(Actor actor){
        actor.transform.parent = transform;
        //actor.transform.localPosition = new Vector3();
    }

    public override void OnStopInteract(Actor actor){
        actor.transform.parent = null;
    }

    void Update(){
        timer += Time.deltaTime * 3f;
        desiredPosition.x = originalPosition.x + Mathf.Sin(timer) * 2f;
        transform.position = desiredPosition;
    }
}
