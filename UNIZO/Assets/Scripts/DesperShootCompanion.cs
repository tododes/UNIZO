using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesperShootCompanion : ShootingActor {

    protected override void spawnBullet(){
        base.spawnBullet();
        bulletActivationSetup(Vector3.left);
    }
}
