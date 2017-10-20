using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class DungeonLevelView : MonoBehaviour {

    [SerializeField] private Text[] detailTexts;
    private StringBuilder starConcatenator;
	
    void Start(){
        starConcatenator = new StringBuilder();
        GetComponent<Button>().onClick.AddListener(OnClick);
        detailTexts = GetComponentsInChildren<Text>();
        //UpdateView();
    }

    private void OnClick(){
        InterSceneImage.singleton.FinishScene("Game Scene");
    }

    public void UpdateView(DungeonLevel dungeonLevel){
        if(starConcatenator.Length > 0)
            starConcatenator.Remove(0, dungeonLevel.getDifficulty());
        for (int i = 0; i < dungeonLevel.getDifficulty(); i++)
            starConcatenator.Append("*");

        detailTexts[0].text = "Name : " + dungeonLevel.getName();
        detailTexts[1].text = "Difficulty : " + starConcatenator.ToString();
    }
}
