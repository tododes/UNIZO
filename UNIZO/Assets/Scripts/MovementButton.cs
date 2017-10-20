using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    protected Player playerToBeControlled;

    protected virtual void Start(){
        playerToBeControlled = Player.singleton;
    }

    public void OnPointerDown(PointerEventData eventData){
        onPressed();
    }

    public void OnPointerUp(PointerEventData eventData){
        onReleased();
    }

    public virtual void onPressed(){
        //
    }

    public virtual void onReleased(){
        
    }
}
