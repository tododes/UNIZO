using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : Bullet {

    [SerializeField] private GameObject explosionObj;

    public override void OnInteract(Actor actor){
        Instantiate(explosionObj, transform.position, Quaternion.identity);
        base.OnInteract(actor);
    }
}
