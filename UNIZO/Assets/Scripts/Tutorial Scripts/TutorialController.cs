using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class TutorialController : MonoBehaviour {

    private List<Action> actions = new List<Action>();
    private int currentIndex;

    [SerializeField] private Player tutoredPlayer;
    [SerializeField] private TutorText tutorialText;
    [SerializeField] private Canvas inputCanvas;
    [SerializeField] private TutorialInputCanvas tutorialInputCanvas;
    [SerializeField] private GameObject inputInstruction;
    [SerializeField] private Companion companionPrefab, newCompanion;

    private StringBuilder sb;

	void Start () {
        currentIndex = 0;
        sb = new StringBuilder();
        tutorialInputCanvas = inputCanvas.GetComponent<TutorialInputCanvas>();
        tutoredPlayer = Player.singleton;
        actions.Add(()=> {
            if (Input.GetMouseButtonDown(0)){
                currentIndex++;
                tutorialText.DisableTutorialText();
            }
        });

        actions.Add(() => {
            inputCanvas.enabled = true;
            inputInstruction.SetActive(true);
            if (tutorialInputCanvas.isInputTutorialFinished()){
                inputInstruction.SetActive(false);
                InvokeActionWithDelay(() => { currentIndex++; }, 3);
            }
        });

        actions.Add(() => {
            if (!newCompanion){
                newCompanion = Instantiate(companionPrefab);
                if(sb.Length > 0)
                    sb.Remove(0, sb.Length);
                sb.Append("This is your companion");
                tutorialText.EnableTutorialText(sb.ToString(), 2);
            }
        });
    }

	void Update () {
        actions[currentIndex].Invoke();
	}

    private void InvokeActionWithDelay(Action action, float delay)
    {
        StartCoroutine(invoke(action, delay));
    }

    private IEnumerator invoke(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action.Invoke();
    }
}
