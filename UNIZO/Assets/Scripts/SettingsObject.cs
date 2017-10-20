using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsObject : MonoBehaviour {

    [SerializeField]
    private Settings settingsData;

    private List<AudioSource> audioSources;

	// Use this for initialization
	void Start () {
        audioSources = new List<AudioSource>(FindObjectsOfType<AudioSource>());
		if(GameStorage.Exists(Application.persistentDataPath + SaveKey.SETTINGSDATA_KEY)){
            settingsData = GameStorage.Load<Settings>(Application.persistentDataPath + SaveKey.SETTINGSDATA_KEY);
            foreach (AudioSource asrc in audioSources) {
                if (asrc.gameObject.tag.Equals("AudioSource - Music")){
                    asrc.volume = settingsData.musicVolume;
                }
                else if (asrc.gameObject.tag.Equals("AudioSource - SFX")){
                    asrc.volume = settingsData.sfxVolume;
                }
            }
        }
        else{
            settingsData = new Settings();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
