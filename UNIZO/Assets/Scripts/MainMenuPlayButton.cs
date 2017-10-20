using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPlayButton : NextSceneButton {

    

    protected override void GoToNextScene(){
        nextSceneIndex = playerPreviouslySaved? 0 : 1;
        base.GoToNextScene();
    }

    public void NotifyThatPlayerHasSavedBefore(){
        playerPreviouslySaved = true;
    }
}
