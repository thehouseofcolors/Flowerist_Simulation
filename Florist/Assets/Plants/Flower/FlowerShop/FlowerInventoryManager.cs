// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class FlowerInventoryManager : MonoBehaviour
// {
//     [Header("UI References")]
//     public Transform flowerPanelParent;
//     public GameObject flowerPanelPrefab;

//     private List<InventoryItem> flowerInventory;

//     private void Start()
//     {
//         flowerInventory = MainInventoryManager.Instance.GetFlowerInventory();
//         RefreshFlowerUI();
//     }

//     public void RefreshFlowerUI()
//     {
//         // Similar implementation to SeedInventoryManager
//         // ...
//     }

//     public void AddFlower(PlantData plantData, int quantity)
//     {
//         // Similar implementation to AddSeed
//         // ...
//     }

//     public bool RemoveFlower(PlantData plantData, int quantity)
//     {
//         var inventory = MainInventoryManager.Instance.GetFlowerInventory();
//         InventoryItem item = inventory.Find(i => i.plantData == plantData);
        
//         if (item != null)
//         {
//             item.quantity -= quantity;
//             if (item.quantity <= 0)
//             {
//                 inventory.Remove(item);
//             }
//             MainInventoryManager.Instance.SaveInventory();
//             RefreshFlowerUI();
//             return true;
//         }
//         return false;
//     }
// }

