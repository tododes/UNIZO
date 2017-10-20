using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : ShootingActor, IFollower
{
    private const float FOLLOW_THRESHOLD = 0.01f;

    private bool timeToWalk;
    private Vector3 destination;
    private Vector3 walkDirection;

    public void jump(float power){
        body.AddForce(Vector3.up * power);
    }

    public void walk(Vector3 destination){
        this.destination = destination;
        walkDirection = destination - transform.position;
        timeToWalk = true;
    }

    public void walk(Vector2 destination){
        
    }

    void Update(){
        if (timeToWalk){
            transform.Translate(walkDirection * 3f * Time.deltaTime);
            if(Vector3.Distance(transform.position, destination) <= FOLLOW_THRESHOLD){
                timeToWalk = false;
            }
        }
    }
}
