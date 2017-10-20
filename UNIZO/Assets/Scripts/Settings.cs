using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Settings : SaveableObject {

    public float musicVolume;
    public float sfxVolume;
    public Settings(){
        musicVolume = sfxVolume = 1f;
    }
}
