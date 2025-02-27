using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// **📌 JSON Kayıt Yapısı**
[System.Serializable]
public class InventoryData
{
    public List<InventoryItem> seeds;
    public List<InventoryItem> flowers;
}

[System.Serializable]
public class InventoryItem
{
    public PlantData plantData;
    public int quantity;
}
public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> seeds = new List<InventoryItem>();  // Satın alınan tohumlar
    public List<InventoryItem> flowers = new List<InventoryItem>(); // Hasat edilen çiçekler

    private string savePath; // Kaydetme dosya yolu

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/inventory.json";
        LoadInventory(); // Oyun başlarken envanteri yükle
    }
   
    public void AddSeed(PlantData plant, int amount = 1)
    {
        InventoryItem item = seeds.Find(x => x.plantData == plant);
        if (item != null)
            item.quantity += amount;
        else
            seeds.Add(new InventoryItem { plantData = plant, quantity = amount });
    }

    public void AddFlower(PlantData plant, int amount = 1)
    {
        InventoryItem item = flowers.Find(x => x.plantData == plant);
        if (item != null)
            item.quantity += amount;
        else
            flowers.Add(new InventoryItem { plantData = plant, quantity = amount });
    }

   
    public bool RemoveSeed(PlantData plant, int amount = 1)
    {
        InventoryItem item = seeds.Find(x => x.plantData == plant);
        if (item != null && item.quantity >= amount)
        {
            item.quantity -= amount;
            if (item.quantity <= 0)
                seeds.Remove(item);
            return true;
        }
        return false;
    }


    public bool SellFlower(PlantData plant, int amount = 1)
    {
        InventoryItem item = flowers.Find(x => x.plantData == plant);
        if (item != null && item.quantity >= amount)
        {
            item.quantity -= amount;
            if (item.quantity <= 0)
                flowers.Remove(item);
            return true;
        }
        return false;
    }
    
    
    // **📌 Envanteri Kaydetme**
    private void SaveInventory()
    {
        InventoryData data = new InventoryData { seeds = seeds, flowers = flowers };
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("📁 Envanter kaydedildi!");
    }

    // **📌 Envanteri Yükleme**
    private void LoadInventory()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            InventoryData data = JsonUtility.FromJson<InventoryData>(json);

            seeds = data.seeds;
            flowers = data.flowers;

            Debug.Log("📂 Envanter yüklendi!");
        }
        else
        {
            Debug.LogWarning("📄 Kayıtlı envanter bulunamadı, yeni envanter oluşturuluyor...");
        }
    }
}
