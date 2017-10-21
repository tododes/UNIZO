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

    public void jump(float power){
        body.AddForce(Vector3.up * power);
    }

    public void walk(Transform destination){
        destinationToReach = destination;
        //this.destination = destination;
        //this.destination = new Vector3(destination.x, transform.position.y, transform.position.z);
        
        //Debug.Log("Destination : " + this.destination);
        //Debug.Log("Current : " + transform.position);
        //timeToWalk = true;
    }

    void Update(){
        if (destinationToReach)
        {
            float distance = Vector3.Distance(transform.position, destinationToReach.position);
            walkDirection = destinationToReach.position - transform.position;
            if (isInTheWrongOrientation())
                TurnAround();
            if (distance > FOLLOW_THRESHOLD)
            {
                transform.Translate(walkDirection * 5f * Time.deltaTime);
            }
        }
    
        //if (timeToWalk){
        //    transform.Translate(walkDirection * 5f * Time.deltaTime);
        //    float distance = Vector3.Distance(transform.position, destination);
        //    Debug.Log(distance);
        //    if (distance <= FOLLOW_THRESHOLD){
        //        Debug.Log("Destination : " + this.destination);
        //        Debug.Log("Current : " + transform.position);
        //        timeToWalk = false;
        //    }
        //}
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
