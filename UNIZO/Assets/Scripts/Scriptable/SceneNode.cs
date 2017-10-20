using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNode : ScriptableObject {

    public string sceneName;
    public bool visited;

    [SerializeField] public List<SceneNode> parent = new List<SceneNode>();
    [SerializeField] private List<SceneNode> children = new List<SceneNode>();

    public SceneNode getChildAt(int index) { return children[index]; }
    public int getChildCount() { return children.Count; }
    public void addChild(SceneNode newChild) {
        if (!children.Contains(newChild))
            children.Add(newChild);
    }

    public SceneNode getParentAt(int index) { return parent[index]; }
    public int getParentCount() { return parent.Count; }
    public void addParent(SceneNode newChild) {
        if(!parent.Contains(newChild))
            parent.Add(newChild);
    }

    public void clearParent() { parent.Clear(); }
}
