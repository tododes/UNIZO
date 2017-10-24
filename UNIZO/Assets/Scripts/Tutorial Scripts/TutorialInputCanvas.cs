using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialInputCanvas : MonoBehaviour {

    [SerializeField] private List<int> buttonValues = new List<int>();
    [SerializeField] private int totalPoint;

    // Use this for initialization
    void Start () {
		for(int i = 0; i < 3; i++){
            buttonValues.Add(1);
        }
    }

    public void pressTutorialButton(int index){
        totalPoint += buttonValues[index];
        buttonValues[index]--;
    }
	
    public bool isInputTutorialFinished() { return totalPoint >= 3; }

    public void ResetInputTutorial() { totalPoint = 0; }
}
