using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Interactable {

    public Vector2 direction;
    private GameWorld gameWorld;

    [SerializeField] private float speed;

    public override void OnInteract(Actor actor)
    {
        Player victim = (Player)actor;
        if(victim)
            victim.receiveDamage();
        gameObject.SetActive(false);
    }

    protected virtual void Start(){
        gameWorld = GameWorld.singleton; 
    }

    protected void Update(){
        if(gameWorld.TimeScale > 0f)
            transform.Translate(direction * speed * Time.deltaTime * gameWorld.TimeScale);
    }
}
