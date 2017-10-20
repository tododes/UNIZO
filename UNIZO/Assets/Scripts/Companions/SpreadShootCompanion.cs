using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShootCompanion : ShootingActor {

    protected override void spawnBullet(){
        bulletActivationSetup(Vector2.right);
        bulletActivationSetup(Vector3.forward * 15f, Vector2.right);
        bulletActivationSetup(Vector3.forward * -15f, Vector2.right);
        //Bullet bulletObj = Instantiate(bullet, transform.position, bulletPoint.transform.rotation);
        //bulletObj.direction = Vector2.right;

        //bulletObj = Instantiate(bullet, transform.position, bulletPoint.transform.rotation);
        //bulletObj.transform.eulerAngles += Vector3.forward * 15f;
        //bulletObj.direction = Vector2.right;

        //bulletObj = Instantiate(bullet, transform.position, bulletPoint.transform.rotation);
        //bulletObj.transform.eulerAngles += Vector3.forward * -15f;
        //bulletObj.direction = Vector2.right;

    }
}
