// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;


// public class FlowerManager : MonoBehaviour
// {
//     public void AddFlower(PlantData plant, int amount = 1)
//     {
//         var flowers = MainInventoryManager.Instance.GetFlowerInventory();
//         InventoryItem item = flowers.Find(x => x.plantData == plant);

//         if (item != null) item.quantity += amount;
//         else flowers.Add(new InventoryItem { plantData = plant, quantity = amount });

//         MainInventoryManager.Instance.SaveInventory();
//         Debug.Log($"🌸 Added {amount} {plant.plantName} flowers");
//     }

//     public bool SellFlower(PlantData plant, int amount, out int totalEarnings)
//     {
//         var flowers = MainInventoryManager.Instance.GetFlowerInventory();
//         InventoryItem item = flowers.Find(x => x.plantData == plant);
//         totalEarnings = 0;

//         if (item != null && item.quantity >= amount)
//         {
//             totalEarnings = amount * plant.flower.sellPrice;
//             item.quantity -= amount;
//             if (item.quantity <= 0) flowers.Remove(item);
//             MainInventoryManager.Instance.SaveInventory();
//             return true;
//         }

//         Debug.LogWarning($"❌ Not enough {plant.plantName} flowers to sell!");
//         return false;
//     }
// }