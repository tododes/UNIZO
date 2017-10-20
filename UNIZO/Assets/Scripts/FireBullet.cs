using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet {

    public override void OnInteract(Actor actor){
        Player victim = (Player)actor;
        if (victim)
            victim.receiveDamage();
    }

    protected override void Start()
    {
        base.Start();
        Destroy(gameObject, 5f);
    }
}
