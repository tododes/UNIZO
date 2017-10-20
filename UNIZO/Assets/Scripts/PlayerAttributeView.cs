using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributeView : MonoBehaviour, PlayerObserver {

    [SerializeField] private Slider healthSlider, lungCapacitySlider;
    [SerializeField] private Text goldText, crystalText;
    [SerializeField] private Image playerImage;

    [SerializeField] private PlayerNameToImageConverter nameToImageConverter;
    //[SerializeField]
    //private StringBuilder coinDisplayBuilder, crystalDisplayBuilder;

    void Awake () {
        goldText = GameObject.Find("Gold Text").GetComponent<Text>();
        crystalText = GameObject.Find("Crystal Text").GetComponent<Text>();
        healthSlider = GameObject.Find("HP Slider").GetComponent<Slider>();
        lungCapacitySlider = GameObject.Find("Oxygen Slider").GetComponent<Slider>();
        playerImage = GameObject.Find("Player Image").GetComponent<Image>();
    }

    public void update(string playerName, float healthPercentage, int coin, int crystal){
        Sprite sprite = nameToImageConverter.convert(playerName);
        if(sprite)
            playerImage.sprite = sprite;

        healthSlider.value = healthPercentage;
        healthSlider.maxValue = 1f;
        goldText.text = coin.ToString();
        crystalText.text = crystal.ToString();
    }

    public void update(float healthPercentage, int coin, int crystal){
        healthSlider.value = healthPercentage;
        healthSlider.maxValue = 1f;
        goldText.text = coin.ToString();
        crystalText.text = crystal.ToString();
    }

    public void update(bool underwater, float lungCapacityPercentage, float healthPercentage, int coin, int crystal)
    {
        lungCapacitySlider.gameObject.SetActive(underwater);
        lungCapacitySlider.value = lungCapacityPercentage;
        lungCapacitySlider.maxValue = 1f;
        healthSlider.value = healthPercentage;
        healthSlider.maxValue = 1f;
        goldText.text = coin.ToString();
        crystalText.text = crystal.ToString();
    }
}
