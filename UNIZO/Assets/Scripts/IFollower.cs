using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFollower {

    void walk(Vector2 destination);
    void walk(Vector3 destination);
    void jump(float power);
}
