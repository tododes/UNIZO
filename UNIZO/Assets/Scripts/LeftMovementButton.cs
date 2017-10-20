using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovementButton : MovementButton {

    [SerializeField] private Vector3 desiredScale;

    protected override void Start()
    {
        base.Start();
        desiredScale = playerToBeControlled.transform.localScale;
    }

    public override void onPressed(){
        playerToBeControlled.OnStartWalking();
        if (playerToBeControlled.transform.localScale.x > 0f){
            desiredScale.x = -playerToBeControlled.transform.localScale.x;
            desiredScale.y = playerToBeControlled.transform.localScale.y;
            desiredScale.z = playerToBeControlled.transform.localScale.z;
            playerToBeControlled.transform.localScale = desiredScale;
        }
    }

    public override void onReleased(){
        playerToBeControlled.OnStopWalking();
    }
}
