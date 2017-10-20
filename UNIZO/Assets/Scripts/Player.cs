using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor, Swimmable, IAnimatable, Jumper {

    [SerializeField] private int JumpPower;
    private int myCoin;
    private int myCrystal;

    public static Player singleton { get; private set; }
    private Rigidbody2D body;
    public bool readyToAccomplishTheMission { get; private set; }

    [SerializeField]
    private PlayerSaveData mySaveData;
   
    [SerializeField]
    private bool grounded;

    [SerializeField]
    private WalkButton leftButton, rightButton;

    [SerializeField]
    private Checkpoint lastVisitedCheckpoint;

    [SerializeField]
    private List<PlayerObserver> observers = new List<PlayerObserver>();

    [SerializeField]
    private float speed;

    [SerializeField]
    private float lungCapacity, currLungCapacity;

    [SerializeField]
    private bool underwater;

    [SerializeField]
    private List<Background> sceneBackgrounds;

    private Vector3 startingPosition;
    //[SerializeField]
    //private Vector3 velocity;

    [SerializeField]
    private SpriteAnimationController mySpriteController;

    [SerializeField]
    private Companion myCompanion;

    [SerializeField]
    private Transform followPoint;

    public float getSpeed() { return speed; }
    public void ModifySpeed(float amount) { speed += amount; }

    void Awake(){
        singleton = this;
    }

    public void registerObserver(PlayerObserver po){
        observers.Add(po);
    }

    public void removeObserver(PlayerObserver po){
        if(observers.Contains(po))
            observers.Remove(po);
    }

    public void notifyObservers(){
        for(int i = 0; i < observers.Count; i++){
            observers[i].update(gameObject.name, health * 1f / maxHealth, myCoin, myCrystal);
        }
    }

    public void notifyObserversAboutUnderwaterStatus(){
        for (int i = 0; i < observers.Count; i++){
            observers[i].update(underwater, currLungCapacity / lungCapacity, health * 1f / maxHealth, myCoin, myCrystal);
        }
    }

    public void setLastVisitedCheckpoint(Checkpoint c){
        lastVisitedCheckpoint = c;
        GameStorage.Save<Checkpoint>(lastVisitedCheckpoint, Application.persistentDataPath + SaveKey.LASTPLAYERCHECKPOINT_KEY);
    }

    public Vector3 getLastCheckpointPosition() {
        if(lastVisitedCheckpoint)
            return lastVisitedCheckpoint.transform.position;
        return startingPosition;
    }

    public override void AddHealth(){
        base.AddHealth();
        notifyObservers();
    }

    public void ModifyGoldAndCrystal(int g, int c){
        myCoin += g;
        myCrystal += c;
        notifyObservers();
    }

    public override void receiveDamage(){
        base.receiveDamage();
        notifyObservers();
    }

    protected override void Start(){
        base.Start();

        if (GameStorage.Exists(Application.persistentDataPath + SaveKey.PLAYERDATA_KEY)){
            mySaveData = GameStorage.Load<PlayerSaveData>(Application.persistentDataPath + SaveKey.PLAYERDATA_KEY);
            gameObject.name = mySaveData.name;
            myCoin = mySaveData.getGold();
            myCrystal = mySaveData.getCrystal();
        }

        if (GameStorage.Exists(Application.persistentDataPath + SaveKey.LASTPLAYERCHECKPOINT_KEY)){
            Vector3 checkpointPosition = GameStorage.Load<Vector3>(Application.persistentDataPath + SaveKey.LASTPLAYERCHECKPOINT_KEY);
            transform.position = checkpointPosition;
        }
        else{
            transform.position = startingPosition;
        }
        body = GetComponent<Rigidbody2D>();
        JumpPower = 2;
        readyToAccomplishTheMission = true;

        sceneBackgrounds = new List<Background>(FindObjectsOfType<Background>());

        registerObserver(GameObject.Find("Player Attribute UI").GetComponent<PlayerAttributeView>());
        notifyObservers();
        notifyObserversAboutUnderwaterStatus();
        mySpriteController = GetComponent<SpriteAnimationController>();
        animate(PlayerMovementStatus.IDLE, 0.5f, true);
        followPoint = transform.FindChild("Follow Point");
        //position2D = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (leftButton && leftButton.isBeingPressed()){
            walkToLeft();
        }
        if (rightButton && rightButton.isBeingPressed()){
            walkToRight();
        }

        if (!leftButton.isBeingPressed() && !rightButton.isBeingPressed())
            body.velocity = new Vector2(0f, body.velocity.y);
        body.velocity *= GameWorld.singleton.TimeScale;

        if (!grounded){
            notifyBackgroundsAboutDirection(body.velocity);
        }
 
    }

    void Update(){
        if (!underwater){
            if (currLungCapacity < lungCapacity)
                currLungCapacity += 2f * Time.deltaTime;
            else
                currLungCapacity = lungCapacity;
        }

        if (lungCapacity <= 0f){
            lungCapacity = 0f;
            health--;
        }
    }

    public override void OnActorDeath(){
        if(lastVisitedCheckpoint)
            GameStorage.Save<Vector3>(lastVisitedCheckpoint.transform.position, Application.persistentDataPath + SaveKey.LASTPLAYERCHECKPOINT_KEY);
        Level.singleton.MissionFail();
    }

    public void OnStartWalking(){
        animate(PlayerMovementStatus.WALK, 0.5f, true);
        myCompanion.walk(followPoint.position);
    }

    public void OnStopWalking(){
        animate(PlayerMovementStatus.IDLE, 0.5f, true);
    }

    public void walkToLeft()
    {
        body.velocity = new Vector2(Vector2.left.x * speed, body.velocity.y);
        notifyBackgroundsAboutDirection(body.velocity);
       
    }

    public void walkToRight()
    {
        body.velocity = new Vector2(Vector2.right.x * speed, body.velocity.y);
        notifyBackgroundsAboutDirection(body.velocity);
        
    }

    public void jump()
    {
        if (JumpPower > 0){
            
            body.AddForce(Vector2.up * 450f);
            JumpPower--;
           
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log(coll.collider.name);
        if (coll.collider.name.Contains("Floor"))
        {
            if (!grounded)
            {
                grounded = true;
                onGrounded();
            }
        }
        else if (coll.collider.name.Contains("Wall"))
            body.gravityScale = 0.1f;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Interactable i = coll.GetComponent<Interactable>();
        Debug.Log("enter");
        if (i){
            i.OnInteract(this);
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        Interactable i = coll.GetComponent<Interactable>();
        if (i)
        {
            i.OnContinuouslyInteract(this);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        Interactable i = coll.GetComponent<Interactable>();
        Debug.Log("exit");
        if (i)
        {
            i.OnStopInteract(this);
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.collider.name.Contains("Floor")){
            grounded = false;
            onStartJump();
        }
        else if (coll.collider.name.Contains("Wall"))
            body.gravityScale = 1f;

    }

    public void onGrounded()
    {
        JumpPower = 2;
        animate(PlayerMovementStatus.IDLE, 0.5f, true);
    }

    public void startSwimming(){
        underwater = true;
        notifyObserversAboutUnderwaterStatus();
    }

    public void staySwimming(){
        currLungCapacity -= Time.deltaTime;
        notifyObserversAboutUnderwaterStatus();
    }

    public void stopSwimming(){
        underwater = false;
        notifyObserversAboutUnderwaterStatus();
    }

    public void animate(PlayerMovementStatus status, float animationDuration, bool repeatable){
        mySpriteController.UpdatePlayerMovementStatus(status, animationDuration, repeatable);
    }

    public void pauseAnimation()
    {
        
    }

    public void startAnimation(){
       
    }

    public void registerBackground(Background b){
        sceneBackgrounds.Add(b);
    }

    private void notifyBackgroundsAboutDirection(Vector2 direction){
        for(int i = 0; i < sceneBackgrounds.Count; i++){
            sceneBackgrounds[i].parallax(direction);
        }
    }

    public void onStartJump() {
        animate(PlayerMovementStatus.JUMP, 0.9f, false);
        myCompanion.jump(250f);
    }

    public PlayerSaveData getCurrentSaveData(){
        return mySaveData;
    }
}
