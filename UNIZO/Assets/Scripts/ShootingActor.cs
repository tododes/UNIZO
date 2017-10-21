using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingActor : Actor {

    [SerializeField]
    protected bool timeToShoot;

    [SerializeField]
    protected float shootingInterval;

    [SerializeField]
    protected Bullet bullet;

    [SerializeField]
    protected Transform bulletPoint;

    [SerializeField]
    protected Vector3 bulletInitialEulerAngles;

    [SerializeField]
    protected GameWorld gameWorld;

    [SerializeField]
    protected ObjectPool objectPool;

    [SerializeField]
    protected List<Bullet> bulletsObj;

    private int bulletShootCounter = 0;

    [SerializeField]
    protected int maxBulletAmount;

    public void startShooting()
    {
        StartCoroutine(shoot());
    }

    protected override void Start() {
        base.Start();
        
        gameWorld = GameWorld.singleton;
        if(Level.singleton)
            objectPool = Level.singleton.getObjectPool();
        timeToShoot = true;
        for(int i = 0; i < maxBulletAmount; i++) {
            Bullet newObj = Instantiate<Bullet>(bullet);
            bulletsObj[i] = objectPool.registerObject<Bullet>(newObj);
        }
        //startShooting();
    }

    protected IEnumerator shoot()
    {
        while (timeToShoot)
        {
            if (gameWorld.TimeScale > Time.deltaTime)
            {
                spawnBullet();
                yield return new WaitForSeconds(shootingInterval / gameWorld.TimeScale);
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    protected virtual void spawnBullet()
    {
        bulletActivationSetup(Vector3.right);
    }

    protected void bulletActivationSetup(Vector3 direction){
        bulletsObj[bulletShootCounter].gameObject.SetActive(true);
        if (bulletShootCounter < maxBulletAmount - 1){
            bulletShootCounter++;
        }
        else{
            bulletShootCounter = 0;
        }
        bulletsObj[bulletShootCounter].direction = direction;
    }

    protected void bulletActivationSetup(Vector3 additionalEulerAngles, Vector3 direction){
        bulletsObj[bulletShootCounter].gameObject.SetActive(true);
        bulletsObj[bulletShootCounter].transform.eulerAngles += additionalEulerAngles;
        if (bulletShootCounter < maxBulletAmount - 1)
        {
            bulletShootCounter++;
        }
        else
        {
            bulletShootCounter = 0;
        }
        bulletsObj[bulletShootCounter].direction = direction;
    }
}
