using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueText : MonoBehaviour {

    private SpriteRenderer myTextMeshRenderer;
    private float timer;
    private Color desiredColor;
    private InterSceneImage IImage;

	// Use this for initialization
	void Start () {
        myTextMeshRenderer = GetComponent<SpriteRenderer>();
        desiredColor = Color.white;
        IImage = InterSceneImage.singleton;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime * 3f;
        if(timer >= Mathf.PI){
            timer = 0f;
        }
        desiredColor.a = Mathf.Abs(Mathf.Cos(timer));
        myTextMeshRenderer.color = desiredColor;

        if (Input.GetMouseButtonDown(0)){
            SceneNavigation.singleton.ProceedToNextScene(0);
        }
	}
}
