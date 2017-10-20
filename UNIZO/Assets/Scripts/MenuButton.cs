using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuButton : MonoBehaviour {

    protected Animator onClickAnimator;
    [SerializeField] protected float animationSpeedMultiplier;
    [SerializeField] protected Action onClickAction;
    protected bool playerPreviouslySaved;

    protected virtual void Start(){
        onClickAnimator = GetComponent<Animator>();
        setAction();
    }

    protected void OnMouseDown(){
        if(!onClickAnimator)
            onClickAnimator = GetComponent<Animator>();
        onClickAnimator.speed = animationSpeedMultiplier;
        onClickAnimator.enabled = true;
        AnimatorStateInfo info = onClickAnimator.GetCurrentAnimatorStateInfo(0);
        StartCoroutine(delayBeforeClickReaction(info.length / animationSpeedMultiplier));
    }

    protected IEnumerator delayBeforeClickReaction(float delayInterval){
        Debug.Log("Pressed");
        yield return new WaitForSeconds(delayInterval);
        onClickAnimator.enabled = false;
        onClickAction.Invoke();
        //InterSceneImage.singleton.FinishScene(nextSceneName);
    }

    protected virtual void setAction(){
  
    }

    public void NotifyThatPlayerHasSavedBefore(){
        playerPreviouslySaved = true;
    }
}
