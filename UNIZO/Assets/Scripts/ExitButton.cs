using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MenuButton {

    [SerializeField]
    private AreYouSurePanel exitPanel;

    protected override void setAction()
    {
        onClickAction = () => {
            MainmenuController.singleton.SaveGameData();
            exitPanel.Trigger();
        };
    }
}
