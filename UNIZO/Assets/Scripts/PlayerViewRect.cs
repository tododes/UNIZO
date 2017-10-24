using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewRect : MonoBehaviour, PlayerObserver {

    [SerializeField] private GameObject clueArrow;
    private Vector3 originalLocalPos;

    void Start(){
        clueArrow = transform.GetChild(0).gameObject;
        originalLocalPos = clueArrow.transform.localPosition;
        clueArrow.SetActive(false);
    }

    public void update(Vector2 position){
        transform.position = position;
    }

    public void update(float healthPercentage, int coin, int crystal)
    {
        
    }

    public void update(string playerName, float healthPercentage, int coin, int crystal)
    {
        
    }

    public void update(bool underwater, float lungCapacityPercentage, float healthPercentage, int coin, int crystal)
    {
       
    }

    void OnTriggerEnter2D(Collider2D other){
        Interactable i = other.GetComponent<Interactable>();
        if (i){
            i.OnInteract(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        Interactable i = other.GetComponent<Interactable>();
        if (i)
        {
            i.OnStopInteract(gameObject);
        }
    }

    public GameObject getClueArrow() { return clueArrow; }

    public void reclaimMyClueArrow(GameObject oldClueArrow){
        oldClueArrow.transform.parent = transform;
        oldClueArrow.transform.localPosition = originalLocalPos;
        oldClueArrow.transform.eulerAngles = Vector3.forward * 90f;
    }
}
