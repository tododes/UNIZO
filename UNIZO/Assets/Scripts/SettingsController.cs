using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsController : MenuController {

    private Settings currentSettings;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    // Use this for initialization
    protected override void Start() {
        base.Start();
        if(File.Exists(Application.persistentDataPath + SaveKey.SETTINGSDATA_KEY)){
            currentSettings = GameStorage.Load<Settings>(Application.persistentDataPath + SaveKey.SETTINGSDATA_KEY);
        }
        else {
            currentSettings = new Settings();
        }
        musicSlider.value = currentSettings.musicVolume;
        sfxSlider.value = currentSettings.sfxVolume;  
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void saveSettings(){
        currentSettings.musicVolume = musicSlider.value;
        currentSettings.sfxVolume = sfxSlider.value;
        GameStorage.Save<Settings>(currentSettings, Application.persistentDataPath + SaveKey.SETTINGSDATA_KEY);
    }

    public override void SaveGameData()
    {
        base.SaveGameData();
        Debug.Log("Settings data");
    }
}
