using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SeedStoreManager : MonoBehaviour
{
    [SerializeField] PlantCatalogSO plantCatalogSO;

    [Header("seed")]
    [SerializeField] SeedItemController seedShopItemPrefab;
    [SerializeField] Transform seedShop;
    
    [Header("Inventory")]
    [SerializeField] InventoryItemController inventoryItemPrefab;
    [SerializeField] Transform inventory;
    void Start()
    {
        GenerateSeedShop(plantCatalogSO.Catalog.Values);
    }

    void GenerateSeedShop(IEnumerable<PlantDefinitionSO> _catalog)
    {
        foreach(var plant in _catalog)
        {
            SeedItemController item = Instantiate(seedShopItemPrefab, seedShop);
            item.InitializeData(plant, PlayerPrefs.GetInt(GameManager.LevelKey, 1));
            UpdateInventoryItem(plant.species, plant);
        }
    }
    void UpdateInventoryItem(PlantSpecies species,PlantDefinitionSO plantDefinition)
    {
        InventoryItemController inventoryItem= Instantiate(inventoryItemPrefab, inventory);
        inventoryItem.InitializeItem(species, plantDefinition);
    }
    
    

}
