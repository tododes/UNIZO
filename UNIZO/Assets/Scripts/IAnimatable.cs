using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimatable {

    void animate(PlayerMovementStatus status, float animationDuration, bool repeatable);
    void startAnimation();
    void pauseAnimation();
}
