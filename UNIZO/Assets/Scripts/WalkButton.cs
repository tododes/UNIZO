using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WalkButton : Button, IPointerDownHandler, IPointerUpHandler {

    private bool pressed;
    public new void OnPointerDown(PointerEventData eventData){
        base.OnPointerDown(eventData);
        pressed = true;
    }

    public new void OnPointerUp(PointerEventData eventData){
        base.OnPointerUp(eventData);
        pressed = false;
    }

    public bool isBeingPressed() { return pressed; }

    // Use this for initialization
    new void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
