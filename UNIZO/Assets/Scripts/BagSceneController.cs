using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagSceneController : MenuController {

    public static BagSceneController singleton { get; private set; }
    private const int PLAYER_MAX_SLOT = 7;
    private const int PLAYER_BATTLEITEM_MAX_SLOT = 4;
    private const int PLAYER_ARMORYITEM_MAX_SLOT = 3;

    [SerializeField]
    private List<InventoryItemView> battleInventoryItemViews;

    [SerializeField]
    private List<InventoryItemView> armoryInventoryItemViews;

    [SerializeField]
    private List<PlayerSlotView> slotItemViews;

    [SerializeField]
    private List<PlayerSlotView> armoryItemViews;

    [SerializeField]
    private List<InventoryContainer> inventoryContainers;

    void Awake(){
        singleton = this;
        base.Start();
    }

    protected override void Start(){
        battleInventoryItemViews = new List<InventoryItemView>(GameObject.Find("Battle Inventory Container").GetComponentsInChildren<InventoryItemView>());
        armoryInventoryItemViews = new List<InventoryItemView>(GameObject.Find("Armory Inventory Container").GetComponentsInChildren<InventoryItemView>());
        slotItemViews = new List<PlayerSlotView>(GameObject.Find("Battle Item Container").GetComponentsInChildren<PlayerSlotView>());
        armoryItemViews = new List<PlayerSlotView>(GameObject.Find("Armory Item Container").GetComponentsInChildren<PlayerSlotView>());

        inventoryContainers.Add(GameObject.Find("Battle Inventory Container").GetComponent<InventoryContainer>());
        inventoryContainers.Add(GameObject.Find("Armory Inventory Container").GetComponent<InventoryContainer>());

        LoadItemToInventory();
        base.Start();
    }

    private void LoadItemToInventory(){
        int battleItemCount = 0;
        int armoryItemCount = 0;
        for (int i = 0; i < currentSaveData.getSavedItemCount(); i++){
            Item item = currentSaveData.getSavedItemAt(i);
            if (item.type == ItemType.BATTLE){
                battleInventoryItemViews[battleItemCount].updateItemDisplay(item);
                battleInventoryItemViews[battleItemCount].gameObject.GetComponent<InventoryButton>().setMyItem(item);
                battleItemCount++;
            }
            else{
                armoryInventoryItemViews[armoryItemCount].updateItemDisplay(item);
                armoryInventoryItemViews[armoryItemCount].gameObject.GetComponent<InventoryButton>().setMyItem(item);
                armoryItemCount++;
            }
        }

        for (int i = battleItemCount; i < battleInventoryItemViews.Count; i++) {
            battleInventoryItemViews[i].updateItemDisplay(null);
        }

        for (int i = armoryItemCount; i < armoryInventoryItemViews.Count; i++){
            armoryInventoryItemViews[i].updateItemDisplay(null);
        }

        for(int i = 0; i < inventoryContainers.Count; i++){
            inventoryContainers[i].validateNoItemText();
        }
    }

    public override void SaveGameData(){
        base.SaveGameData();
        Debug.Log("Bag scene data");
    }

    public void UpdatePlayerEquippedItem(Item item){
        if(item.type == ItemType.BATTLE){
            currentSaveData.EquipOrUnequipItemToBattleSlot(item);
            for (int i = 0; i < currentSaveData.getBattleItemCount(); i++){
                slotItemViews[i].updateItemDisplay(currentSaveData.getBattleItemAt(i));
            }
            for (int i = currentSaveData.getBattleItemCount(); i < PLAYER_BATTLEITEM_MAX_SLOT; i++){
                slotItemViews[i].updateItemDisplay(null);
            }
        }
        else if (item.type == ItemType.ARMORY){
            currentSaveData.EquipOrUnequipItemToArmorySlot(item);
            for (int i = 0; i < currentSaveData.getArmoryItemCount(); i++){
                armoryItemViews[i].updateItemDisplay(currentSaveData.getArmoryItemAt(i));
            }
            for (int i = currentSaveData.getArmoryItemCount(); i < PLAYER_ARMORYITEM_MAX_SLOT; i++){
                armoryItemViews[i].updateItemDisplay(null);
            }
        }
    }
}
