using System.Collections.Generic;
using UnityEngine;


public class SeedShopManager: MonoBehaviour
{
    [SerializeField] List<PlantDataSO> catalog = new List<PlantDataSO>();
    [SerializeField] SeedShopItem seedShopItemPrefab;
    [SerializeField] Transform seedShopParent;

    [SerializeField] SeedInventoryItem seedInventoryItemPrefab;
    [SerializeField] Transform seedInventoryParent;    

    private List<SeedShopItem> seedShopInventory =new List<SeedShopItem>();
    
    private List<SeedInventoryItem> seedInventory = new List<SeedInventoryItem>();
    void Start()
    {
        foreach(var plant in catalog)
        {
            SeedShopItem item = Instantiate(seedShopItemPrefab, seedShopParent);
            item.Setup(plant);
            seedShopInventory.Add(item);


        }
    }
    void OnEnable()
    {
       EventManager.OnSeedPurchaseRequested+=HandlePurchase;
    }


    void HandlePurchase(PlantDataSO plant, int purchaseQuantity)
    {
        foreach(var seed in seedInventory)
        {
            if(seed._species == plant.species)
            {
                int q = seed.InventoryQuantity;
                q += purchaseQuantity;
                seed.SetInventoryQuantity(q);
                return;
            }
        }
        SeedInventoryItem item = Instantiate(seedInventoryItemPrefab, seedInventoryParent);
        item.Setup(plant, purchaseQuantity);
        seedInventory.Add(item);

    }


}