using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : NextSceneButton {

    [SerializeField] private MainmenuController mainMenuController;

    protected override void GoToNextScene(){
        nextSceneIndex = mainMenuController.shouldPlayerBeTutored() ? 1 : 0;
        base.GoToNextScene();
    }
}
