using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNavigation : MonoBehaviour {

    public static SceneNavigation singleton { get; private set; }

    public SceneGraph tree;
    [SerializeField] private InterSceneImage isi;

    public delegate void SaveSceneContent();
    public SaveSceneContent saveGameContent;
  
    void Awake(){
        singleton = this;
    }

	// Use this for initialization
	void Start () {
        //tree.ResetAllNodeParent();
        //tree.Initialize();
        tree.DFS(Application.loadedLevelName);
        isi = InterSceneImage.singleton;
        //tree.ResetTree();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            BackToPreviousScene(0);
	}

    public void BackToPreviousScene(int parentIndex){
        saveGameContent();
        isi.FinishScene(tree.getCurrentNode().parent[parentIndex].sceneName);
        tree.switchToParent(parentIndex);
    }

    public void ProceedToNextScene(int sceneIndex){
        saveGameContent();
        isi.FinishScene(tree.getCurrentNode().getChildAt(sceneIndex).sceneName);
        tree.switchToChild(sceneIndex);
    }
}
