using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickAgent : MonoBehaviour {

    public Joystick myJoyStick;
    private Vector3 moveDirection;
	// Use this for initialization
	void Start () {
        moveDirection = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        moveDirection.x = myJoyStick.getMovementDirection().x;
        moveDirection.z = myJoyStick.getMovementDirection().y;
        transform.Translate(moveDirection * 0.25f * Time.deltaTime);
	}
}
