using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//add to GameManager object in the scene
//this is for the inventory registry
//this is a singleton class that will be used to save and load the inventory data
public class InventoryRegistry : Singleton<InventoryRegistry>
{
    private string savePath;
    private InventoryItem inventoryData;
    [SerializeField] Inventory seedInventory;
    [SerializeField] Inventory flowerInventory;
    protected override void Awake()
    {
        base.Awake(); // Ensure Singleton behavior is applied

        savePath = Application.persistentDataPath + "/inventory.json";
        Debug.Log("Save Path: " + savePath);

        inventoryData = LoadInventory();
    }

    private void OnApplicationQuit()
    {
        SaveInventory();
    }
    
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveInventory();
        }
    }

    public void SaveInventory()
    {
        // if (inventoryData == null)
        // {
        //     Debug.LogError("Inventory data is null. Cannot save.");
        //     return;
        // }

        string json = JsonUtility.ToJson(inventoryData, true);
        File.WriteAllText(savePath, json);
        Debug.Log("💾 Saved all inventory data!");
        PlayerPrefs.Save(); // Save PlayerPrefs changes
    }

    private InventoryItem LoadInventory()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            Debug.Log("📂 Loaded inventory data!");

            return JsonUtility.FromJson<InventoryItem>(json);
        }

        Debug.Log("🆕 No existing inventory found, creating a new one.");
        return new InventoryItem(); // Return a new InventoryItem if no file exists
    }

    public InventoryItem GetInventoryData()
    {
        return inventoryData;
    }
}
