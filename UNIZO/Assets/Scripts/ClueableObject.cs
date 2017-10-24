using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueableObject : MonoBehaviour {

    private Transform childHead;
    private Vector3 desiredEulerAngles;
    private GameObject currentClueArrow;

	void Start () {
        childHead = transform.GetChild(0);
        desiredEulerAngles = Vector3.zero;
	}

    public void setClueArrowToMe(Transform clueArrowTransform){
        currentClueArrow = clueArrowTransform.gameObject;
        clueArrowTransform.position = childHead.position;
        clueArrowTransform.eulerAngles = desiredEulerAngles;
        clueArrowTransform.parent = transform;
    }

    public GameObject getCurrentClueArrow(){
        return currentClueArrow;
    }
}
