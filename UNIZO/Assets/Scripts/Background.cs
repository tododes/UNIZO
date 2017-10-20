using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    [SerializeField] private int layer;
    [SerializeField] private Player featuredPlayer;
    [SerializeField] private float desiredMinimumYAxis;
    //[SerializeField] private float desiredLandedPosition_Y;

	void Start () {
        desiredMinimumYAxis = transform.position.y;
        //char layerChar = name[name.Length - 1];
        //layer = (int)layerChar - '0';
        //featuredPlayer = Player.singleton;
	}

    //public void setDesiredLandedPosition(float y){
    //    desiredLandedPosition_Y = y;
    //}

    //public void validateYPosition(float playerLandedPosition_Y){
    //    float diff = desiredLandedPosition_Y - playerLandedPosition_Y;
    //    Debug.Log(diff);
    //    transform.position += Vector3.up * diff;
    //}

    public void parallax(Vector3 direction){
        float parallaxFactor = layer / 10f;
        transform.Translate(direction * parallaxFactor * Time.deltaTime);
    }
}
