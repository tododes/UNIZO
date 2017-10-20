using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public enum ItemType { BATTLE = 0, ARMORY = 1 }

[System.Serializable]
public class Item {

    [XmlAttribute("name")] public string name;
    [XmlAttribute("description")] public string description;
    [XmlAttribute("price")] public int price;
    [XmlAttribute("type")] public ItemType type;

    private bool IamChanged;

    public virtual void Effect(){

    }

    public bool isChanged() { return IamChanged; }

    public void OnInitialize(){
        IamChanged = true;
    }

    public string getDescription() { return description; }

    public void Modify(){
        IamChanged = true;
    }

    public void OnFinishedModifying(){
        IamChanged = false;
    }

    public override bool Equals(object obj)
    {
        Item otherItem = (Item)obj;
        return name.CompareTo(otherItem.name) == 0 && description.CompareTo(otherItem.description) == 0;
    }
}
