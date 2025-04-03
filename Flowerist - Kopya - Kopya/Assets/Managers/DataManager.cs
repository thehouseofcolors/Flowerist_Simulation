using System.IO;
using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class InventoryData
{
    public List<string> seeds = new List<string>();
    public List<string> flowers = new List<string>();
    
    public void AddSeed(string id) => seeds.Add(id);
    public bool HasSeed(string id) => seeds.Contains(id);
}

[System.Serializable]
public class GardenData
{
    public List<GardenPlant> plants = new List<GardenPlant>();
    
    public void AddPlant(string seedId, Vector3 position) => 
        plants.Add(new GardenPlant(seedId, position));
}

[System.Serializable]
public class GardenPlant
{
    public string plantId;
    public Vector3 position;
    public float growthProgress;
    public string currentStage = "seedling";

    public GardenPlant(string id, Vector3 pos)
    {
        plantId = id;
        position = pos;
    }
}
public class DataManager : Singleton<DataManager> 
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

    protected override void Awake() 
    {
        base.Awake();
        LoadAllData();
    }

    // Improved economy properties
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