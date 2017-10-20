using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveableObject {
    public string ID;
    public string filename;

    public SaveableObject() { }

    public SaveableObject(string file){
        filename = file;
    }
}
