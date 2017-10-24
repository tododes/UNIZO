using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueArrow : MonoBehaviour {

    private float time;
    [SerializeField] private Vector3 desiredPosition;
    private float originalYPos;
	// Use this for initialization
	void Start () {
        originalYPos = transform.position.y;
        desiredPosition = new Vector3(transform.position.x, 0, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        time += 16f * Time.deltaTime;
        //desiredPosition.y = transform.position.y + (Mathf.Cos(time) * 0.025f);
        //transform.position = desiredPosition;
        transform.Translate(Vector3.up * (Mathf.Cos(time) * 3f) * Time.deltaTime);
	}
}
