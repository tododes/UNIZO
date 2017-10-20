using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneButton : MenuButton {

    [SerializeField] protected int nextSceneIndex;
    [SerializeField] protected SceneNavigation sceneNav;

    protected override void Start(){
        base.Start();
        onClickAnimator.enabled = false;
    }

    protected override void setAction(){
        onClickAction = () => {
            if(!sceneNav)
                sceneNav = SceneNavigation.singleton;
            GoToNextScene();
        };
    }

    protected virtual void GoToNextScene(){
        sceneNav.ProceedToNextScene(nextSceneIndex);
    }
}
