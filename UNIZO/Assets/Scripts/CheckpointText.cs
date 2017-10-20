using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointText : AreYouSurePanel {

    private WaitForSeconds waitForTwoSeconds = new WaitForSeconds(2);

    public override void Trigger(){
        base.Trigger();
        StartCoroutine(inflateText());
    }

    private IEnumerator inflateText(){
        yield return waitForTwoSeconds;
        No();
    }
}
