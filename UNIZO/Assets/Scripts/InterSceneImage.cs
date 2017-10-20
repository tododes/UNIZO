using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InterSceneImage : Image
{
    public static InterSceneImage singleton { get; private set; }
    public bool onScene;
    public string nextScene;

    private Color fadeOperator;
    private Image image;
    private Canvas canvas;

    [SerializeField] private GameObject loadingImage;

    private new void Awake(){
        singleton = this;
    }

    private new void Start() {
        base.Start();
        image = GetComponent<Image>();
        canvas = GetComponentInParent<Canvas>();
        canvas.sortingOrder = 11;
        //loadingImage.SetActive(false);
        fadeOperator = new Color(0, 0, 0, 1.25f);
        StartScene();
    }

    public void StartScene(){
        onScene = true;
    }

    public void FinishScene(string scene){
        onScene = false;
        canvas.sortingOrder = 11;
        nextScene = scene;
    }

    public void ReOpenScene()
    {
        onScene = false;
        canvas.sortingOrder = 11;
        nextScene = Application.loadedLevelName;
    }

    void Update(){
        if(onScene && color.a > 0f){
            color -= fadeOperator * Time.deltaTime;
        }
        else if (onScene && color.a <= 0f){
            canvas.sortingOrder = -1;
        }

        if (!onScene && color.a < 1f){
            color += fadeOperator * Time.deltaTime;
        }
        else if(!onScene && color.a >= 1f){
            StartCoroutine(ActivateLoadingScreen());
        }
    }

    private IEnumerator ActivateLoadingScreen()
    {
        AsyncOperation async = Application.LoadLevelAsync(nextScene);
        //loadingImage.SetActive(true);
        yield return new WaitForSeconds(async.progress);
    }

}
