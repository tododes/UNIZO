using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFollower {

    void walk(Transform destination);
    void jump(float power);
}
