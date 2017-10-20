using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ShootingActor {

    private Player player;

    protected override void Start(){
        base.Start();
        player = Player.singleton;
        bulletInitialEulerAngles = Vector3.zero;
        gameWorld = GameWorld.singleton;
        startShooting();
    }
	
    protected override void spawnBullet(){
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        float cosValue = (player.getPosition().x - getPosition().x) / distanceToPlayer;
        float radValue = Mathf.Acos(cosValue);
        float degreeValue = Mathf.Rad2Deg * radValue;
        bulletInitialEulerAngles.z = degreeValue;
        Bullet bulletObj = Instantiate(bullet, transform.position, bulletPoint.transform.rotation);
        bulletObj.direction = Vector2.right;
        bulletObj.transform.eulerAngles = bulletInitialEulerAngles;
    }
}
