using System;
using TMPro;
using UnityEngine;


public class EconomyManager : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.OnSeedPurchaseRequested += HandleSeedPurchase;
        EventManager.OnFlowerSellRequested += HandleFlowerSale;
    }

    private void OnDisable()
    {
        // Unsubscribe from events
        EventManager.OnSeedPurchaseRequested -= HandleSeedPurchase;
        EventManager.OnFlowerSellRequested -= HandleFlowerSale;
    }

    private void HandleSeedPurchase(PlantDataSO plant,int purchaseQuantity)
    {
        if (TryBuySeed(plant.seedStage.seedShopItem.purchasePrice*purchaseQuantity))
        {
            EventManager.UpdateSeedInventory(plant, 1);
            
            // Success logic
            Debug.Log($"Purchased {plant.seedStage.sprite} seed");
        }
    }

    private void HandleFlowerSale(Species species, FlowerStage flower)
    {
        SellFlower(flower);
        Debug.Log($"Sold {flower.icon} flower");
    }

    /// <summary>
    /// Adds money to player's balance with validation
    /// </summary>
    /// <param name="amount">Positive value to add</param>
    public void AddMoney(int amount) 
    {
        if (amount <= 0)
        {
            Debug.LogWarning($"Invalid money addition amount: {amount}. Amount must be positive.");
            return;
        }

        int oldBalance = DataManager.Money;
        DataManager.Money += amount;
        Debug.Log($"Money added: +{amount}. Balance: {oldBalance} → {DataManager.Money}");
    }

    /// <summary>
    /// Deducts money from player's balance with validation
    /// </summary>
    /// <param name="amount">Positive value to deduct</param>
    public void SpendMoney(int amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning($"Invalid spending amount: {amount}. Amount must be positive.");
            return;
        }

        if (DataManager.Money < amount)
        {
            Debug.LogWarning($"Insufficient funds. Required: {amount}, Current: {DataManager.Money}");
            return;
        }

        int oldBalance = DataManager.Money;
        DataManager.Money -= amount;
        Debug.Log($"Money spent: -{amount}. Balance: {oldBalance} → {DataManager.Money}");
    }

    /// <summary>
    /// Attempts to purchase seeds if player has enough money
    /// </summary>
    /// <param name="amount">Cost of seeds</param>
    /// <returns>True if purchase succeeded</returns>
    public bool TryBuySeed(int amount) 
    {
        if (amount <= 0)
        {
            Debug.LogError($"Invalid seed price: {amount}");
            return false;
        }

        if (DataManager.Money >= amount) 
        {
            SpendMoney(amount); 
            Debug.Log($"Seed purchased for {amount}");
            return true;
        }
        
        Debug.Log($"Not enough money for seed purchase. Needed: {amount}, Has: {DataManager.Money}");
        return false;
    }

    /// <summary>
    /// Sells a flower and rewards player with XP and money
    /// </summary>
    /// <param name="flowerData">Flower being sold</param>
    public void SellFlower(FlowerStage flowerData) 
    {
        if (flowerData == null)
        {
            Debug.LogError("Tried to sell null flower data!");
            return;
        }

        int oldMoney = DataManager.Money;
        int oldXP = DataManager.XP;
        
        AddXP(flowerData.xpReward);
        AddMoney(flowerData.sellPrice); // Logging handled in AddMoney()
        
        Debug.Log($"Sold flower for {flowerData.sellPrice} (+{flowerData.xpReward} XP). " +
                 $"Money: {oldMoney}→{DataManager.Money}, XP: {oldXP}→{DataManager.XP}");
    }

    /// <summary>
    /// Adds XP to player's total
    /// </summary>
    /// <param name="xp">Positive XP value</param>
    private void AddXP(int xp) 
    {
        if (xp <= 0)
        {
            Debug.LogWarning($"Invalid XP amount: {xp}. Value must be positive.");
            return;
        }

        DataManager.XP += xp;
        
    }
}
