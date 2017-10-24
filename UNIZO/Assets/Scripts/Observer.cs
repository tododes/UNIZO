using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerObserver {
    void update(float healthPercentage, int coin, int crystal);
    void update(string playerName, float healthPercentage, int coin, int crystal);
    void update(bool underwater, float lungCapacityPercentage, float healthPercentage, int coin, int crystal);
    void update(Vector2 position);
}
