using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour {

    public static ShopView singleton { get; private set; }

    [SerializeField] private Text goldText, crystalText;

    void Awake(){
        singleton = this;
    }

    public void UpdateView(PlayerSaveData psd){
        goldText.text = psd.getGold().ToString();
        crystalText.text = psd.getCrystal().ToString();
    }
}
