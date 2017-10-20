using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionAccomplishedPanel : AreYouSurePanel {

    public override void Yes(string name){
        InterSceneImage.singleton.FinishScene(name);
        Index = 0;
    }

    public override void No(){
        InterSceneImage.singleton.FinishScene("MainMenu");
        Index = 0;
    }
}
