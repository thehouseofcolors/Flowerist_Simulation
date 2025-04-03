using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public struct PlayerData
{
    public int playerLevel;
    public int playerCurrency;
    
    
    

}
public class GameManager : Singleton<GameManager>  
{   
    
    public static string LevelKey = "CurrentLevel";
    public static string CurrencyKey = "CurrentCurrency";

    
    [SerializeField]public InventorySO seedInventory;
    [SerializeField] PlantCatalogSO plantCatalog;
    public static Action<int > OnLevelChange;

    
    private string saveFilePath;
    private string plantCatalogFilePath;
    protected override void Awake()
    {
        base.Awake();
        saveFilePath = Path.Combine(Application.persistentDataPath, "savefile.json");
        plantCatalogFilePath = Path.Combine(Application.persistentDataPath, "plantCatalogData.json");
    
        
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("GameStarted")) 
        {
            Debug.Log("loaded game is starting");
            LoadGame(); 
            LoadPlantCatalog();
        }
        else 
        {
            Debug.Log("new game is starting");
            PlayerPrefs.SetInt("GameStarted", 1);
            InitializeNewGame(); 
        }
       
    }

    
    void InitializeNewGame()
    {
        PlayerPrefs.SetInt(LevelKey, 1);
        PlayerPrefs.SetInt(CurrencyKey, 500);
        PlayerPrefs.Save();
        SaveGame();
        SavePlantCatalog();
    }

    
    public void SaveGame()
    {
        PlayerData data = new PlayerData
        {
            playerLevel = PlayerPrefs.GetInt(LevelKey),
            playerCurrency = PlayerPrefs.GetInt(CurrencyKey),

        };
        
        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savefile.json";
        File.WriteAllText(path, json);


        Debug.Log("Oyun kaydedildi: " + json);
        Debug.Log("Kayıt dosyası yolu: " + path);
    }

            
    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Debug.Log("Yüklenen JSON: " + json);  // Dosya içeriğini görmek için

            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            PlayerPrefs.SetInt(CurrencyKey, data.playerCurrency);

            PlayerPrefs.SetInt(LevelKey, data.playerLevel);

            PlayerPrefs.Save();  // PlayerPrefs değişikliklerini kalıcı yap

            Debug.Log("Yüklenen Değerler - Seviye: " + data.playerLevel + 
                    ", Para: " + data.playerCurrency);
        }
        else
        {
            Debug.LogError("Kaydedilmiş veri bulunamadı.");
        }
    }

    void OnApplicationQuit()
    {
        SaveGame();
        SavePlantCatalog();
    }

 
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) 
        {
            Debug.Log("Oyun arka plana alındı, kayıt yapılıyor...");
            SaveGame();
            SavePlantCatalog();
        }
    }

    // ✅ PlantCatalog'u kaydet
    private void SavePlantCatalog()
    {
        if (plantCatalog == null) return;

        string jsonData = JsonUtility.ToJson(plantCatalog, true);
        File.WriteAllText(plantCatalogFilePath, jsonData);
        Debug.Log("🌿 PlantCatalog verisi kaydedildi.");
    }

    // ✅ PlantCatalog'u yükle
    private void LoadPlantCatalog()
    {
        if (File.Exists(plantCatalogFilePath))
        {
            string jsonData = File.ReadAllText(plantCatalogFilePath);
            JsonUtility.FromJsonOverwrite(jsonData, plantCatalog);
            Debug.Log("📥 PlantCatalog başarıyla yüklendi.");
        }
        else
        {
            Debug.Log("🚨 Kaydedilmiş PlantCatalog verisi bulunamadı.");
        }
    }


}  