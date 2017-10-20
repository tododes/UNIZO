using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BuyItemView : MonoBehaviour, IViewer {

    [SerializeField]
    private Button buyButton;
    [SerializeField]
    private Item item;
    [SerializeField]
    private SureBuyPanel sureBuyPanel;
    private Action buyAction;


    void Start()
    {
        buyButton = GetComponentInChildren<Button>();
        buyButton.onClick.AddListener(BuyNewItem);
    }

    private void BuyNewItem()
    {
        Debug.Log("s");
        sureBuyPanel.Trigger(item);
    }

    public void updateItemDisplay(Item i){
        item = i;
    }

    public Item getItem()
    {
        return item;
    }
}
