using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MovementButton {

    public override void onPressed(){
        playerToBeControlled.onStartJump();
    }
}
