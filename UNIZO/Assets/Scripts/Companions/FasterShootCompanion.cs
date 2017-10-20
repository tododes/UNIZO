using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterShootCompanion : ShootingActor {

    [SerializeField] private float shootIntervalReduction;
    [SerializeField] private float shootIntervalLowestThreshold;

    protected override void spawnBullet(){
        base.spawnBullet();
        if(shootingInterval > shootIntervalLowestThreshold){
            shootingInterval -= shootIntervalReduction;
        }
    }
}
