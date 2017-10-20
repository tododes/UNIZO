using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Actor : MonoBehaviour {
    [SerializeField] protected Vector2 position2D;
    [SerializeField] protected int health, maxHealth;
    [SerializeField] protected float animationSpeed;
    [SerializeField] protected int invulnerablePoint;
    [SerializeField] protected Rigidbody2D body;

    protected virtual void Start(){
        position2D.x = transform.position.x;
        position2D.y = transform.position.y;
        body = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate(){
        position2D.x = transform.position.x;
        position2D.y = transform.position.y;
        animationSpeed = GameWorld.singleton.TimeScale;
    }

    protected void LateUpdate(){
        if (health <= 0)
            OnActorDeath();
    }

    public void AddInvulnerablePoint() { invulnerablePoint++; }
    public void instantDead() { health = 0; }

    public virtual void receiveDamage() {
        if (invulnerablePoint <= 0)
            health--;
        else
            invulnerablePoint--;
    }

    public virtual void AddHealth(){
        health++;
    }

    public Vector2 getPosition() { return position2D; }

    public virtual void OnActorDeath(){
        gameObject.SetActive(false);
    }
}
