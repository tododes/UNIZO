using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : ShootingActor, IFollower
{
    private const float FOLLOW_THRESHOLD = 0.1f;

    private bool timeToWalk;
    private Transform destinationToReach;
    private Vector3 walkDirection;
    private GameWorld world;

    public void jump(float power){
        body.AddForce(Vector3.up * power);
    }

    protected override void Start(){
        base.Start();
        world = GameWorld.singleton;
    }

    public void walk(Transform destination){
        destinationToReach = destination;
    }

    void Update(){
        if (destinationToReach)
        {
            float distance = Vector3.Distance(transform.position, destinationToReach.position);
            walkDirection = destinationToReach.position - transform.position;
            if (isInTheWrongOrientation())
                TurnAround();
            if (distance > FOLLOW_THRESHOLD){
                transform.Translate(walkDirection * 5f * Time.deltaTime * world.TimeScale);
            }
        }
    }

    private bool isInTheWrongOrientation(){
        return (walkDirection.x < 0f && transform.localScale.x > 0f) || (walkDirection.x > 0f && transform.localScale.x < 0f);
    }

    private void TurnAround(){
        Vector3 newScale = Vector3.zero;
        newScale.x = -transform.localScale.x;
        newScale.y = transform.localScale.y;
        newScale.z = transform.localScale.z;
        transform.localScale = newScale;
    }
}
