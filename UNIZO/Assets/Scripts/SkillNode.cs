using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillNode : Node {

    [SerializeField] private string skillActionName;

    public string getActionName() { return skillActionName; }
}
