using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Interactable {

    [SerializeField] private int damage;
    [SerializeField] private bool detonated;
    [SerializeField] private CircleCollider2D MyCircleCollider;

    public void Trigger(){
        detonated = true;
        if (!MyCircleCollider.isTrigger)
            MyCircleCollider.isTrigger = true;
    }

    public override void OnInteract(Actor actor){
        actor.receiveDamage();
    }

    void Update(){
        if (detonated){
            MyCircleCollider.radius += 50f * Time.deltaTime;
            Destroy(gameObject, 1f);
        }
    }
}
