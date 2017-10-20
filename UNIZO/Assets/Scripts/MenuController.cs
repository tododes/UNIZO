using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    [SerializeField] protected PlayerSaveData currentSaveData;
    [SerializeField] protected SettingsObject settingsObject;
    [SerializeField] protected ObjectPool objectPool;
    [SerializeField] protected List<MenuButton> menuButtons;

    // Use this for initialization

    protected virtual void Start () {
        GameObject so = Resources.Load("Settings Object") as GameObject;
        GameObject op = Resources.Load("Object Pool") as GameObject;
        op = Instantiate(op);
        objectPool = op.GetComponent<ObjectPool>();
        menuButtons = new List<MenuButton>(FindObjectsOfType<MenuButton>());


        if (GameStorage.Exists(Application.persistentDataPath + SaveKey.PLAYERDATA_KEY)){
            currentSaveData = GameStorage.Load<PlayerSaveData>(Application.persistentDataPath + SaveKey.PLAYERDATA_KEY);
            Debug.Log(currentSaveData.getCompanionData().mySkills.Count);
            for(int i = 0; i < menuButtons.Count; i++){
                menuButtons[i].NotifyThatPlayerHasSavedBefore();
            }
        }
        else{
            currentSaveData = new PlayerSaveData(Application.persistentDataPath + SaveKey.PLAYERDATA_KEY);
            Debug.Log("Player not exist");
        }
        
        SceneNavigation.singleton.saveGameContent += SaveGameData;

        settingsObject = objectPool.registerObject<SettingsObject>(so);
        objectPool.activateObject(settingsObject);
    }

    public PlayerSaveData getCurrentSaveData(){
        return currentSaveData;
    }

    public void setCurrentSaveData(PlayerSaveData psd) { currentSaveData = psd; }

    public virtual void SaveGameData(){
        GameStorage.Save<PlayerSaveData>(currentSaveData, Application.persistentDataPath + SaveKey.PLAYERDATA_KEY);
    }
}
