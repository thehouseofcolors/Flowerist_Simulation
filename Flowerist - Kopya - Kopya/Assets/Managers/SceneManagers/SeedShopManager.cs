using System.Collections.Generic;
using UnityEngine;


public class SeedShopManager: Singleton<SeedShopManager>
{
    [SerializeField] List<PlantDataSO> catalog = new List<PlantDataSO>();
    [SerializeField] SeedShopItem seedShopItemPrefab;
    [SerializeField] Transform seedShopParent;
    private List<SeedShopItem> seedShopInventory =new List<SeedShopItem>();
    void Start()
    {
        foreach(var plant in catalog)
        {
            SeedShopItem item = Instantiate(seedShopItemPrefab, seedShopParent);
            item.Setup(plant.species, plant.seedStage);
            seedShopInventory.Add(item);


        }
    }


}