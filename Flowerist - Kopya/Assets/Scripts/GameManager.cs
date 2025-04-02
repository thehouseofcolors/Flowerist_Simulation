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
    public int playerWater;
    
    

}
public class GameManager : Singleton<GameManager>  
{   
    
    public static string LevelKey = "CurrentLevel";
    public static string CurrencyKey = "CurrentCurrency";
    public static string WaterKey ="CurrentWater";
    
    [SerializeField]public InventorySO seedInventory;
    
    public static Action<int > OnLevelChange;

    
    protected override void Awake()
    {
        base.Awake(); // Ensure Singleton behavior is applied
        if (PlayerPrefs.HasKey("GameStarted")) 
        {
            LoadGame(); // Önceki verileri yükle
        }
        else 
        {
            PlayerPrefs.SetInt("GameStarted", 1);
            InitializeNewGame(); // Yeni bir oyun başlat
        }

    }
    void InitializeNewGame()
    {
        PlayerPrefs.SetInt(LevelKey, 1);
        PlayerPrefs.SetInt(CurrencyKey, 100);
        PlayerPrefs.SetInt(WaterKey, 100);
        

        SaveGame();
    }

    [System.Serializable]
    public class GameData
    {
        public int money;
        public int water;
        public List<string> inventory;
    }

    public void SaveGame()
    {
        PlayerData data = new PlayerData
        {
            playerLevel = PlayerPrefs.GetInt(LevelKey, 1),
            playerCurrency = PlayerPrefs.GetInt(CurrencyKey),
            playerWater = PlayerPrefs.GetInt(WaterKey),
            
        };
        
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

        
    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            PlayerPrefs.SetInt(CurrencyKey, data.playerCurrency);
            PlayerPrefs.SetInt(WaterKey, data.playerWater);
            PlayerPrefs.SetInt(LevelKey, data.playerLevel);


        }else
        {
            Debug.LogError("Kaydedilmiş veri bulunamadı.");
        }
    }

    
    void OnApplicationQuit()
    {
        SaveGame();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) // Uygulama arka plana gidince kaydet
            SaveGame();
    }

    
    public void SaveLevel(int level)
    {
        PlayerPrefs.SetInt(LevelKey, level); 
        PlayerPrefs.Save(); 
    }

    public int LoadLevel()
    {
        return PlayerPrefs.GetInt(LevelKey, 1);
    }
    
}  