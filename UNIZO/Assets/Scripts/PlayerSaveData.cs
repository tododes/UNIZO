using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;



[System.Serializable]
public class PlayerSaveData : SaveableObject {

    public string name;
    public int gold, crystal, loginStreak;
    public CompanionData playerCompanionData;
    [XmlArray("Saved Items")] [XmlArrayItem("Item")] public List<Item> savedItems;
    public List<int> savedItemsAmount;

    [XmlArray("Battle Items")] [XmlArrayItem("Item")] public List<Item> battleItems;
    public List<int> battleItemsAmount;

    [XmlArray("Armory Items")] [XmlArrayItem("Item")] public List<Item> armoryItems;
    public List<int> armoryItemsAmount;

    public int getLoginStreak(){ return loginStreak; }
    public void AddStreak() { loginStreak++; }
    public void ResetStreak() { loginStreak = 0; }

    public int getGold() { return gold; }
    public void modifyGold(int g) { gold += g; }

    public int getCrystal() { return crystal; }
    public void modifyCrystal(int c) { crystal += c; }

    public CompanionData getCompanionData(){
        return playerCompanionData;
    }

    public void setCompanionType(CompanionData newData){
        playerCompanionData = newData;
    }

    public void AddSavedItem(Item i){
        if (savedItems == null)
            savedItems = new List<Item>();
        if (!savedItems.Contains(i)){
            savedItems.Add(i);
            savedItemsAmount.Add(1);
        }
        else{
            int itemIndex = savedItems.IndexOf(i);
            savedItemsAmount[itemIndex]++;
        }    
    }

    public int getSavedItemCount() { return savedItems.Count; }
    public Item getSavedItemAt(int index) { return savedItems[index]; }

    public Item getBattleItemAt(int index) { return battleItems[index]; }
    public int getBattleItemCount() { return battleItems.Count; }
    public void AddBattleItem(Item i){
        if (battleItems == null)
            battleItems = new List<Item>();
        battleItems.Add(i);
    }


    public void EquipOrUnequipItemToBattleSlot(Item item){
        if (battleItems.Count == 0 || !battleItems.Contains(item)){
            battleItems.Add(item);
            int itemIndex = savedItems.IndexOf(item);
            battleItemsAmount.Add(savedItemsAmount[itemIndex]);
        }
        else{
            battleItems.Remove(item);
            int itemIndex = savedItems.IndexOf(item);
            battleItemsAmount.RemoveAt(itemIndex);
        }
    }


    public void EquipOrUnequipItemToArmorySlot(Item item){
        if (armoryItems.Count == 0 || !armoryItems.Contains(item)){
            armoryItems.Add(item);
            int itemIndex = savedItems.IndexOf(item);
            armoryItemsAmount.Add(savedItemsAmount[itemIndex]);
        }
        else{
            armoryItems.Remove(item);
            int itemIndex = savedItems.IndexOf(item);
            armoryItemsAmount.RemoveAt(itemIndex);
        }
    }

    public Item getArmoryItemAt(int index) { return armoryItems[index]; }
    public int getArmoryItemCount() { return armoryItems.Count; }

    public PlayerSaveData(){
        savedItems = new List<Item>();
        gold = 100;
        crystal = 5;
        playerCompanionData = new CompanionData();
    }

    public PlayerSaveData(string filename) : base(filename) {
        savedItems = new List<Item>();
        battleItems = new List<Item>();
        armoryItems = new List<Item>();
        gold = 100;
        crystal = 5;
        playerCompanionData = new CompanionData();
    }

    public void ClaimReward(Reward reward){
        gold += reward.bonusGold;
        crystal += reward.bonusCrystal;
    }

    public void upgradeCompanionSkill(int skillIndex){
        playerCompanionData.mySkillLevels[skillIndex]++;
    }
}
