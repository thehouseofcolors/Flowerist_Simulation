using System.Collections.Generic;
using UnityEngine;


public class SeedShopManager: Singleton<SeedShopManager>
{
    [SerializeField] List<PlantDataSO> catalog = new List<PlantDataSO>();
    [SerializeField] SeedShopItem seedShopItemPrefab;
    [SerializeField] Transform seedShopParent;

    [SerializeField] SeedInventoryItem seedInventoryItemPrefab;
    [SerializeField] Transform seedInventoryParent;    

    private List<SeedShopItem> seedShopInventory =new List<SeedShopItem>();
    
    private List<Species> seedInventory = new List<Species>();
    void Start()
    {
        foreach(var plant in catalog)
        {
            SeedShopItem item = Instantiate(seedShopItemPrefab, seedShopParent);
            item.Setup(plant.species, plant.seedStage);
            seedShopInventory.Add(item);


        }
    }
    void OnEnable()
    {
        EventManager.OnSeedPurchaseRequested+=HandlePurchase;
    }
    void HandlePurchase(Species species, SeedStage seedStage, int purchaseQuantity)
    {
        foreach(var plant in seedInventory)
        {
            if(plant == species)
            {
                seedStage.seedStackData.StackQuantity += purchaseQuantity;
                return;
            }
        }
        SeedInventoryItem item = Instantiate(seedInventoryItemPrefab, seedInventoryParent);
        item.Setup(species, seedStage, purchaseQuantity);
        seedInventory.Add(species);

    }


}