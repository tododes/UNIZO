using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class TutorialController : MonoBehaviour {

    private List<Action> actions = new List<Action>();
    [SerializeField] private int currentIndex;

    [SerializeField] private Player tutoredPlayer;
    [SerializeField] private TutorialPanel tutorPanel;
    [SerializeField] private Canvas inputCanvas;
    [SerializeField] private TutorialInputCanvas tutorialInputCanvas;
    [SerializeField] private GameObject inputInstruction;
    [SerializeField] private Companion companionPrefab, newCompanion;
    [SerializeField] private Enemy tutorEnemy, tutorEnemyPrefab;
    [SerializeField] private Door tutorDoor;
    [SerializeField] private GameObject clueArrow;

    private StringBuilder sb;
    private bool shouldContinue;

	void Start () {
        currentIndex = 0;
        sb = new StringBuilder();
        tutorialInputCanvas = inputCanvas.GetComponent<TutorialInputCanvas>();
        tutoredPlayer = Player.singleton;
        tutorPanel.Trigger("Welcome to the tutorial !!", 0);

        actions.Add(()=> {
            if (Input.GetMouseButtonDown(0)){
                currentIndex++;
                //tutorialText.DisableTutorialText();
                tutorPanel.No();
            }
        });

        actions.Add(() => {
            inputCanvas.enabled = true;
            inputInstruction.SetActive(true);
            if (tutorialInputCanvas.isInputTutorialFinished()){
                currentIndex++;
                shouldContinue = true;
            }
        });

        actions.Add(() => {
            if (shouldContinue){
                Debug.Log("set active false");
                inputInstruction.SetActive(false);
                InvokeActionWithDelay(() => { currentIndex++; }, 3);
                tutorialInputCanvas.ResetInputTutorial();
                shouldContinue = false;
            }
        });

        actions.Add(() => {
            shouldContinue = false;
            if (!newCompanion){
               
                newCompanion = Instantiate(companionPrefab);
                tutoredPlayer.setCompanion(newCompanion);
                if(sb.Length > 0)
                    sb.Remove(0, sb.Length);
                sb.Append("This is your companion");
                //tutorialText.EnableTutorialText(sb.ToString(), 2);
                tutorPanel.Trigger(sb.ToString(), 0);
                InvokeActionWithDelay(() => {
                    currentIndex++;
                    shouldContinue = true;
                }, 2);
            }
        });

        actions.Add(() => {
            shouldContinue = false;
            if (Input.GetMouseButtonDown(0)){
                if (sb.Length > 0)
                    sb.Remove(0, sb.Length);
                sb.Append("It will be your ally\nthroughout your journey");
                //tutorialText.EnableTutorialText(sb.ToString(), 0);
                tutorPanel.Trigger(sb.ToString(), 0);
                InvokeActionWithDelay(() => {
                    currentIndex++;
                    shouldContinue = true;
                }, 0);
            }
        });

        actions.Add(() => {
            shouldContinue = false;
            if (Input.GetMouseButtonDown(0)){
                if (!tutorEnemy){
                    tutorEnemy = Instantiate(tutorEnemyPrefab);
                    if (sb.Length > 0)
                        sb.Remove(0, sb.Length);
                    sb.Append("This is your enemy\nit will try to stop you");
                    //tutorialText.EnableTutorialText(sb.ToString(), 0);
                    tutorPanel.Trigger(sb.ToString(), 0);
                    InvokeActionWithDelay(() => {

                        currentIndex++;
                        shouldContinue = true;
                    }, 2);
                }
            }
        });

        actions.Add(() => {
            shouldContinue = false;
            if (tutorEnemy.isDead() && !shouldContinue){
                //tutorialText.DisableTutorialText();
                tutorPanel.No();
                currentIndex++;
                shouldContinue = true;
                InvokeActionWithDelay(() => {
                    Instantiate(tutorDoor);
                }, 2);
            }
         
        });

        actions.Add(() => {
            shouldContinue = false;
            if (sb.Length > 0)
                sb.Remove(0, sb.Length);
            clueArrow.SetActive(true);
            sb.Append("Go to that door");
            //tutorialText.EnableTutorialText(sb.ToString(), 0);
            tutorPanel.Trigger(sb.ToString(), 0);
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
