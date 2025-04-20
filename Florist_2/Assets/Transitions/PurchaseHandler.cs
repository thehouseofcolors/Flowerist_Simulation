using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseHandler : Singleton<PurchaseHandler>
{
    [SerializeField] public InventorySO seedSO;
    [SerializeField] InventoryItemController inventoryItemPrefab;
    [SerializeField] Transform inventoryParent;
    
    
    public static event Action<PlantSpecies, int> OnSeedInventoryChanged;

    public void PurchaseItem(PlantDefinitionSO plant, int purchaseQuantity)
    {
        int cost = plant.seedData.purchasePrice * purchaseQuantity;
        CurrencyHandler(cost);
        // if(seedSO.inventory.ContainsKey(plant.species))
        // {
        //     seedSO.PurchaseItem(plant, purchaseQuantity);
        // }
        // else
        // {
        //     AddToInventory(plant);
        // }
        
        
        OnSeedInventoryChanged?.Invoke(plant.species, purchaseQuantity);
    }
    public void AddToInventory(PlantDefinitionSO plant)
    {
        InventoryItemController inventoryItem = Instantiate(inventoryItemPrefab, inventoryParent);
        
        inventoryItem.InitializeItem(plant );
    }
    void CurrencyHandler(int cost)
    {
        int currency=PlayerPrefs.GetInt(GameManager.CurrencyKey);
        PlayerPrefs.SetInt(GameManager.CurrencyKey, currency-cost);
        Debug.Log($"new currency {PlayerPrefs.GetInt(GameManager.CurrencyKey)}");
        PlayerPrefs.Save();
       
    }

}
