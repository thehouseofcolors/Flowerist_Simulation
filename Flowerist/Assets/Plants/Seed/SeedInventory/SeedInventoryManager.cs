// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
// using System.Collections.Generic;



// public class SeedInventoryManager : InventoryManager
// {
//     [SerializeField] Inventory seedInventoryList; //data
//     [SerializeField] PanelData panelData; //prefab

//     private SeedInventoryItem seedInventoryItemPrefab;
//     private void Start()
//     {
//         seedInventoryItemPrefab = panelData.seedInventoryItemPrefab;
//         GenerateSeedInventory(seedInventoryItemPrefab, seedInventoryList);
//     }
//     void GenerateSeedInventory(SeedInventoryItem seedInventoryItemPrefab, Inventory inventory)
//     {
//         foreach(var item in inventory.inventoryItems)
//         {
//             SeedInventoryItem seedInventoryItem = Instantiate(seedInventoryItemPrefab, transform);
//             seedInventoryItem.SetUp(item.plantData.seed.seedPackSprite, item.quantity);
//         }
        

//     }

   


// }