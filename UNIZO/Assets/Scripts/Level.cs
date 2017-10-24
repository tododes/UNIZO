using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public static Level singleton { get; private set; }
    private Player currentlyPlayingPlayer;
    private GameWorld gameWorld;
    private AreYouSurePanel pausePanel, missionAccomplishedPanel, missionFailedPanel;

    [SerializeField] private List<Interactable> levelInteractables = new List<Interactable>();
    [SerializeField] private ObjectPool objectPool;

    void Awake(){
        singleton = this;
        
    }
	// Use this for initialization
	void Start () {
        currentlyPlayingPlayer = Player.singleton;
        gameWorld = GameWorld.singleton;
        objectPool = spawnObjectPool();
        pausePanel = GameObject.Find("Pause Panel").GetComponent<AreYouSurePanel>();
        missionAccomplishedPanel = GameObject.Find("Mission Accomplished Panel").GetComponent<MissionAccomplishedPanel>();
        GameObject failedPanelObject = GameObject.Find("Mission Failed Panel");
        if (failedPanelObject)
            missionFailedPanel = failedPanelObject.GetComponent<MissionFailedPanel>();
        for(int i = 0; i < levelInteractables.Count; i++){
            levelInteractables[i] = objectPool.registerObject<Interactable>(levelInteractables[i]);
        }
    }

    private ObjectPool spawnObjectPool(){
        GameObject op = Resources.Load("Object Pool") as GameObject;
        op = Instantiate(op);
        return op.GetComponent<ObjectPool>();
    }

    public ObjectPool getObjectPool() { return objectPool; }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)){
            gameWorld.pauseSystem();
            pausePanel.Trigger();
        }
	}

    public void Accomplish(){
        if (!currentlyPlayingPlayer.readyToAccomplishTheMission)
            return;
        gameWorld.pauseSystem();
        missionAccomplishedPanel.Trigger();
    }

    public void MissionFail(){
        gameWorld.pauseSystem();
        if(missionFailedPanel)
            missionFailedPanel.Trigger();
    }
}
