using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public virtual void OnInteract(Actor actor){
        gameObject.SetActive(false);
    }

    public virtual void OnContinuouslyInteract(Actor actor){

    }

    public virtual void OnStopInteract(Actor actor){

    }

    public virtual void OnInteract(GameObject collObj){
        IsTutorialClueableObject_Enter(collObj);
    }

    public virtual void OnContinuouslyInteract(GameObject collObj){

    }

    public virtual void OnStopInteract(GameObject collObj){
        IsTutorialClueableObject_Exit(collObj);
    }

    protected void IsTutorialClueableObject_Enter(GameObject collObj){
        ClueableObject clueableObj = GetComponent<ClueableObject>();
        if (clueableObj){
            PlayerViewRect pvr = collObj.GetComponent<PlayerViewRect>();
            clueableObj.setClueArrowToMe(pvr.getClueArrow().transform);
        }
    }

    protected void IsTutorialClueableObject_Exit(GameObject collObj){
        ClueableObject clueableObj = GetComponent<ClueableObject>();
        if (clueableObj){
            GameObject clueArrow = clueableObj.getCurrentClueArrow();
            PlayerViewRect pvr = collObj.GetComponent<PlayerViewRect>();
            pvr.reclaimMyClueArrow(clueArrow);
        }
    }
}
