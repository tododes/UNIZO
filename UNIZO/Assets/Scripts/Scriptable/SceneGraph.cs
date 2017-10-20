using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGraph : ScriptableObject {

    public SceneNode root;
    [SerializeField] private SceneNode current;

    [SerializeField]
    private List<SceneNode> allNodes;


    public void Initialize(){
        found = false;
        
    }

    public void switchToParent(int parentIndex){
        current = current.parent[parentIndex];
    }

    public void switchToChild(int childIndex){
        current = current.getChildAt(childIndex);
    }

    public SceneNode getCurrentNode(){
        return current;
    }

    public void ResetTree(){
        ResetDFSStatus();
        ResetTree(root);
    }

    public void ResetAllNodeParent(){
        for(int i = 0; i < allNodes.Count; i++)
        {
            allNodes[i].clearParent();
        }
    }

    private void ResetTree(SceneNode node){
        node.visited = false;
        if (node.getChildCount() <= 0)
            return;

        for (int i = 0; i < node.getChildCount(); i++){
            ResetTree(node.getChildAt(i));
        }
    }

    //private void MapTree(SceneNode node){
    //    if (node.getChildCount() <= 0)
    //        return;
    //    for(int i = 0; i < node.getChildCount(); i++){
    //        //node.getChildAt(i).addParent(node);
    //        //node.getChildAt(i).clearParent();
    //        MapTree(node.getChildAt(i));
    //    }
    //}

    [SerializeField] private bool found;

    public void DFS(string sceneName){
        ResetDFSStatus();
        getCurrentSceneInTree(root, sceneName);
    }

    public void ResetDFSStatus() { found = false; }
    public void getCurrentSceneInTree(SceneNode node, string nodeName){

        if (node.name == nodeName){
            found = true;
            current = node;
        }
        else if (node.name != nodeName && !found){
            node.visited = true;
            for (int i = 0; i < node.getChildCount(); i++){
                SceneNode child = node.getChildAt(i);
                if (!child.visited)
                    getCurrentSceneInTree(child, nodeName);
            }
        }
    }
}
