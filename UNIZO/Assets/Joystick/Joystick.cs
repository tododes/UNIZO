using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private const int WIDTH = 1920;
    private const int HEIGHT = 1080;

    [SerializeField] private LayerMask joystickMask;
    [SerializeField] private RectTransform rect;
    [SerializeField] private PointerEventData currentEventData;
    [SerializeField] private float maxDistance;

    private Vector3 originalPos;
    public void OnPointerDown(PointerEventData eventData)
    {
        currentEventData = eventData;
        rect.position = eventData.position;
    }

    // Use this for initialization
    void Start () {
        rect = GetComponent<RectTransform>();
        originalPos = rect.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(currentEventData != null){
            float distance = Vector3.Distance(currentEventData.position, originalPos);
            if (distance < maxDistance)
                rect.position = currentEventData.position;
            else{
                float cosValue = (currentEventData.position.x - originalPos.x) / distance;
                float sinValue = (currentEventData.position.y - originalPos.y) / distance;
                float px = cosValue * maxDistance;
                float py = sinValue * maxDistance;
                rect.position = originalPos + new Vector3(px, py, 0);
            }
        }
            
    }

    public void OnPointerUp(PointerEventData eventData){
        currentEventData = null;
        rect.position = originalPos;
    }

    public Vector3 getMovementDirection(){
        return rect.position - originalPos;
    }
}
