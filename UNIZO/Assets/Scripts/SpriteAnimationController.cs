using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerMovementStatus
{
    WALK, IDLE, JUMP
}

public class SpriteAnimationController : MonoBehaviour {

    private Dictionary<PlayerMovementStatus, List<Sprite>> movementStatusToSpritesheet = new Dictionary<PlayerMovementStatus, List<Sprite>>();

    [SerializeField]
    private List<Sprite> walkSprite;

    [SerializeField]
    private List<Sprite> idleSprite;

    [SerializeField]
    private List<Sprite> jumpSprite;

    [SerializeField]
    private List<Sprite> currentSprite;

    private SpriteRenderer myRenderer;
    private int spriteCounter;
    private bool hasAnimationStarted;
    private bool isAnimationRepeatable;
    private float currentAnimationDuration;

    void Awake(){
        movementStatusToSpritesheet.Add(PlayerMovementStatus.WALK, walkSprite);
        movementStatusToSpritesheet.Add(PlayerMovementStatus.IDLE, idleSprite);
        movementStatusToSpritesheet.Add(PlayerMovementStatus.JUMP, jumpSprite);
    }

    void Start () {
        spriteCounter = 0;
        hasAnimationStarted = false;
        isAnimationRepeatable = false;
        myRenderer = GetComponent<SpriteRenderer>();
    }

    public void UpdatePlayerMovementStatus(PlayerMovementStatus status, float animationDuration, bool repeatable)
    {
        currentSprite = movementStatusToSpritesheet[status];
        spriteCounter = 0;
        currentAnimationDuration = animationDuration;
        isAnimationRepeatable = repeatable;
        if (!hasAnimationStarted){
            StartCoroutine(animate());
            hasAnimationStarted = true;
        }
    }

    public IEnumerator animate()
    {
        int counter = 0;
        while (true)
        {
            if (GameWorld.singleton.TimeScale > 0f){
                myRenderer.sprite = currentSprite[spriteCounter];
                spriteCounter++;
                if (spriteCounter > currentSprite.Count - 1){
                    if (isAnimationRepeatable)
                        spriteCounter = 0;
                    else
                        spriteCounter = currentSprite.Count - 1;
                }
                yield return new WaitForSeconds((currentAnimationDuration * GameWorld.singleton.TimeScale) / currentSprite.Count);
            }
            else
                yield return null;
        }
    }
}
