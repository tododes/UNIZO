using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShootCompanion : ShootingActor {

    private bool bulletAlreadySpawned;

    protected override void spawnBullet(){
        StartCoroutine(spawnTripleBullet());
    }

    private IEnumerator spawnTripleBullet(){
        for (int i = 0; i < 3; i++){
            base.spawnBullet();
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);
    }
}
