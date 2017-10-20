using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionFailedPanel : AreYouSurePanel {

    public override void Yes(string name)
    {
        GameStorage.Save<Vector3>(Player.singleton.getLastCheckpointPosition(), Application.persistentDataPath + SaveKey.LASTPLAYERCHECKPOINT_KEY);
        InterSceneImage.singleton.FinishScene(Application.loadedLevelName);
        Index = 0;
    }

    public override void No()
    {
        InterSceneImage.singleton.FinishScene("MainMenu");
        Index = 0;
    }
}
