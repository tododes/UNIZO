﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class TutorText : MonoBehaviour {

    private Text myText;
    private StringBuilder sb;

	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
        sb = new StringBuilder();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnableTutorialText(string command, int delay){
        Debug.Log("enable tutor text");
        if (sb.Length > 0)
            sb.Remove(0, sb.Length);
        sb.Append(command);
        myText.text = sb.ToString();
        StartCoroutine(EnableTutorialTextWithDelay(delay));
    }

    private IEnumerator EnableTutorialTextWithDelay(float delay){
        yield return new WaitForSeconds(delay);
        myText.enabled = true;
    }

    public void DisableTutorialText(){
        if (sb.Length > 0)
            sb.Remove(0, sb.Length);
        myText.enabled = false;
    }
}
