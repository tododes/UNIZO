using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel : AreYouSurePanel {

    [SerializeField] private TutorText tutorText;
    private string currentCommand;
    private int currentCommandDelay;

    protected override void onTriggerFinished(){
        tutorText.EnableTutorialText(currentCommand, currentCommandDelay);
    }

    public void Trigger(string commandName, int delay){
        currentCommand = commandName;
        currentCommandDelay = delay;
        Trigger();
    }

    public override void No(){
        tutorText.DisableTutorialText();
        base.No();
    }
}
