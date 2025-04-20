using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SeedStoreManager : Singleton<SeedStoreManager>
{
    [Header("The Catalog")]
    [SerializeField] PlantCatalogSO plantCatalogSO;

    [Header("seed")]
    [SerializeField] SeedItemController seedShopItemPrefab;
    [SerializeField] Transform seedShop;
    
    
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
            
        }
    }

}
