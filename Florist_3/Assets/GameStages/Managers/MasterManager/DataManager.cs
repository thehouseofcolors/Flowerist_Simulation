using System.IO;
using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class InventoryData
{
    
}

[System.Serializable]
public class GardenData
{
    
}

[System.Serializable]
public class GardenPlant
{
    
}


public class DataManager : MonoBehaviour
{
    // PlayerPrefs keys (static for global access)
    private const string MONEY_KEY = "PlayerMoney";
    private const string LEVEL_KEY = "PlayerLevel";
    private const string XP_KEY = "PlayerXP";

    // File paths
    private string InventoryPath => Path.Combine(Application.persistentDataPath, "inventory.json");
    private string GardenPath => Path.Combine(Application.persistentDataPath, "garden.json");

    // Current game state
    public InventoryData Inventory { get; private set; } = new InventoryData();
    public GardenData Garden { get; private set; } = new GardenData();

    protected void Awake() 
    {
        LoadAllData();
    }
    public static int Money
    {
        get => PlayerPrefs.GetInt(MONEY_KEY, 1000);
        set 
        {
            PlayerPrefs.SetInt(MONEY_KEY, value);
            PlayerPrefs.Save(); // Explicit save after modification
        }
    }

    public static int Level
    {
        get => PlayerPrefs.GetInt(LEVEL_KEY, 1);
        set 
        {
            PlayerPrefs.SetInt(LEVEL_KEY, value);
            PlayerPrefs.Save();
        }
    }

    public static int XP
    {
        get => PlayerPrefs.GetInt(XP_KEY, 0);
        set 
        {
            PlayerPrefs.SetInt(XP_KEY, value);
            PlayerPrefs.Save();
        }
    }

    public void LoadAllData()
    {
        try 
        {
            // Inventory loading with error handling
            if (File.Exists(InventoryPath))
                Inventory = JsonUtility.FromJson<InventoryData>(File.ReadAllText(InventoryPath)) ?? new InventoryData();
            
            // Garden loading with error handling
            if (File.Exists(GardenPath))
                Garden = JsonUtility.FromJson<GardenData>(File.ReadAllText(GardenPath)) ?? new GardenData();
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Load failed: {e.Message}");
            ResetAllData();
        }
    }

    public void SaveAllData()
    {
        try 
        {
            File.WriteAllText(InventoryPath, JsonUtility.ToJson(Inventory));
            File.WriteAllText(GardenPath, JsonUtility.ToJson(Garden));
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Save failed: {e.Message}");
        }
    }

    public void ResetAllData()
    {
        // Reset PlayerPrefs
        PlayerPrefs.DeleteKey(MONEY_KEY);
        PlayerPrefs.DeleteKey(LEVEL_KEY);
        PlayerPrefs.DeleteKey(XP_KEY);
        
        // Reset file-based data
        Inventory = new InventoryData();
        Garden = new GardenData();
        SaveAllData();
        
        // Set default values
        Money = 1000;
        Level = 1;
        XP = 0;
    }
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) SaveAllData();
    }
    private void OnApplicationQuit()
    {
        SaveAllData(); // 📌 Oyun kapanırken veriyi kaydet
    }
}