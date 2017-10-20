using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.Text;

[System.Serializable]
public class CompanionData {

    public CompanionType myType;
    [XmlArray("Skills")][XmlArrayItem("string")] public List<string> mySkills;
    [XmlArray("Skill Levels")][XmlArrayItem("int")] public List<int> mySkillLevels;
    private StringBuilder sb = new StringBuilder();

    public CompanionData(){
        myType = CompanionType.SPREADINGSHOOT;
        mySkills = new List<string>();
        mySkillLevels = new List<int>();
    }


    public void AddSkill(string newSkill)
    {
        mySkills.Add(newSkill);
    }

    public void AddSkillLevel(int newSkillLevel)
    {
        mySkillLevels.Add(newSkillLevel);
    }

    public override string ToString(){
        if (sb.Length > 0)
            sb.Remove(0, sb.Length);
        sb.Append((myType == CompanionType.PIERCINGSHOOT) ? "PiercingShoot" : "SpreadingShoot");
        return sb.ToString();

    }
}
