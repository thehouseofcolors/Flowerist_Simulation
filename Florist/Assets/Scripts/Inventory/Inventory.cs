using UnityEngine;
using System.Collections.Generic;

public enum InventoryType { Seeds, Flowers}

[System.Serializable]
public struct InventoryItem 
{
    public PlantData plantData;
    public int quantity;
    public InventoryItem(PlantData _plantData, int _quantity)
    {
        plantData=_plantData;
        quantity=_quantity;
    }
}


[CreateAssetMenu(fileName ="Inventory",menuName ="Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] public InventoryType inventoryType;
    
    //size of the inventory will be changeable in the future
    [SerializeField] public int maxSize = 100; // Maximum size of the inventory
    [SerializeField] public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    public Dictionary<PlantSpecies, InventoryItem> inventoryDictionary = new Dictionary<PlantSpecies, InventoryItem>();

    void OnEnable()
    {
        // Initialize the inventory dictionary with the items in the inventoryItems list
        foreach (var item in inventoryItems)
        {
            if (!inventoryDictionary.ContainsKey(item.plantData.Species))
            {
                inventoryDictionary.Add(item.plantData.Species, item);
            }
        }
    }
    public int GetQuantity(PlantData plantData)
    {
        // Check if the plantData exists in the inventory and return its quantity

        foreach (var item in inventoryItems)
        {
            if (item.plantData == plantData)
            {
                return item.quantity;
            }
        }
        return 0; // Return 0 if the plant data is not found in the inventory
    }
    public int GetQuantity(InventoryItem item)
    {
        // Check if the item exists in the inventory and return its quantity
        foreach (var inventoryItem in inventoryItems)
        {
            if (inventoryItem.plantData == item.plantData)
            {
                return inventoryItem.quantity;
            }
        }
        return 0; // Return 0 if the item is not found in the inventory
    }

    public InventoryItem GetInventoryItem(PlantData plantData)
    {
        return inventoryItems.Find(i => i.plantData == plantData);
    }
    public InventoryItem GetInventoryItem(InventoryItem item)
    {
        return inventoryItems.Find(i => i.plantData == item.plantData);
    }
    public void AddItemToInventory(InventoryItem item)
    {
        int index = inventoryItems.FindIndex(i => i.plantData == item.plantData);
        if (index != -1)
        {
            int newQuantity = inventoryItems[index].quantity + item.quantity;
            if (newQuantity > maxSize) newQuantity = maxSize;  // Maksimum envanter sınırı

            inventoryItems[index] = new InventoryItem(inventoryItems[index].plantData, newQuantity);
        }
        else if (inventoryItems.Count < maxSize)
        {
            inventoryItems.Add(item);
        }
    }

    public void RemoveItemFromInventory(InventoryItem item)
    {
        int index = inventoryItems.FindIndex(i => i.plantData == item.plantData);
        if (index != -1)
        {
            inventoryItems[index] = new InventoryItem(inventoryItems[index].plantData, inventoryItems[index].quantity - item.quantity);
            if (inventoryItems[index].quantity <= 0)
            {
                inventoryItems.RemoveAt(index);
            }
        }
    }

    
}