using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Inventory inventory; // Data (Inventory data)
    [SerializeField] PanelData panelData; // Prefab (UI Prefab)

    private void Start()
    {
        SeedInventoryItem seedInventoryItemPrefab = panelData.seedInventoryItemPrefab;
        GenerateSeedInventory(seedInventoryItemPrefab, inventory);
    }
    void GenerateSeedInventory(SeedInventoryItem seedInventoryItemPrefab, Inventory inventory)
    {
        foreach(var item in inventory.inventoryItems)
        {
            SeedInventoryItem seedInventoryItem = Instantiate(seedInventoryItemPrefab, transform);
            seedInventoryItem.SetUp(item.plantData.seed.seedPackSprite, item.quantity);
        }
        

    }
    public void AddItem(PlantData plant, int quantity)
    {
        inventory.AddItemToInventory(new InventoryItem(plant, quantity));
        UpdateUI();  // UI'yi güncelle
    }

    public void RemoveItem(PlantData plant, int quantity)
    {
        inventory.RemoveItemFromInventory(new InventoryItem(plant, quantity));
        UpdateUI();
    }

    private void UpdateUI()
    {
        // UI güncellemeleri burada yapılır.
    }
}
