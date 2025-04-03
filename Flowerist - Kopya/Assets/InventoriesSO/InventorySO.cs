using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory", order = 0)]
public class InventorySO : ScriptableObject
{
    public Dictionary<PlantSpecies, InventoryItem> inventory = new Dictionary<PlantSpecies, InventoryItem>();

    
   
    public int GetQuantity(PlantSpecies plantSpecies) =>inventory[plantSpecies].inventoryQuantity;

    public InventoryItem GetInventoryItem(PlantSpecies species) => inventory[species];
    
    public void PurchaseItem(PlantDefinitionSO plant, int _quantity)
    {
        PlantSpecies species=plant.species;
        if (!inventory.ContainsKey(species))
        {
            
            // Add new item
            inventory.Add(species, new InventoryItem(species,plant.seedData.packIcon, _quantity));
        }
        else
        {
            // Update existing item
            var existingItem = inventory[species];
            existingItem.inventoryQuantity += _quantity; // Miktarı arttır
            inventory[species] = existingItem;  // Güncellenmiş öğeyi geri koy
        }
            

    }

    


}