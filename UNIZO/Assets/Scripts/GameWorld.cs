using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorld : MonoBehaviour {

    public static GameWorld singleton { get; private set; }

    [Range(0.0f, 1.0f)] public float TimeScale = 1f;
    [Range(0.0f, 1.0f)] public float GravityScale = 1f;

    private float prevGravityScale = 0f;
    private float prevTimeScale = 0f;

    void Awake(){
        singleton = this;
    }

    void FixedUpdate(){
        if(GravityScale != prevGravityScale){
            OnChangeGravity();
        }
        prevGravityScale = GravityScale;

        if (TimeScale != prevTimeScale){
            OnChangeTimeScale();
        }
        prevTimeScale = TimeScale;
    }

    private void OnChangeTimeScale(){
        Rigidbody2D[] bodies2D = FindObjectsOfType<Rigidbody2D>();
        for (int i = 0; i < bodies2D.Length; i++){
            bodies2D[i].gravityScale = TimeScale * GravityScale;
        }
    }

    private void OnChangeGravity(){
        Rigidbody2D[] bodies2D = FindObjectsOfType<Rigidbody2D>();
        for(int i = 0; i < bodies2D.Length; i++){
            bodies2D[i].gravityScale = GravityScale;
        }
    }

    public void pauseSystem() {
        if (TimeScale == 1f)
            TimeScale = 0f;
        else if (TimeScale == 0f)
            TimeScale = 1f;
    }

    
}
