using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;
using System.Collections.ObjectModel;
using System.IO;

public enum PlantSpecies
{
    Daisy, Rose, Tulip, Sunflower, Orchid, 
    Lily, Lavender, Violet, Chamomile, Jasmine
}
// Master catalog to reference all plants
[CreateAssetMenu(fileName = "PlantCatalog", menuName = "Catalog", order = 1)]
public class PlantCatalogSO : ScriptableObject
{
    [SerializeField] private List<PlantDefinitionSO> plants = new List<PlantDefinitionSO>();
    public ReadOnlyDictionary<PlantSpecies, PlantDefinitionSO> Catalog;
    
    private string dataFilePath;


    private void OnEnable()
    {
        InitializeLookup();
        dataFilePath = Path.Combine(Application.persistentDataPath, "plantCatalogData.json");
        LoadData();
    }
    public PlantDefinitionSO GetPlantBySpecies(PlantSpecies species)
    {
        return Catalog.TryGetValue(species, out var plant) ? plant : null;
    }

    private void InitializeLookup()
    {
        if (Catalog != null) return; // Eğer zaten başlatıldıysa, tekrar başlatma.

        var dictionary = new Dictionary<PlantSpecies, PlantDefinitionSO>();
        foreach (var plant in plants)
        {
            if (plant == null) continue;

            if (dictionary.ContainsKey(plant.species))
            {
                Debug.LogError($"Duplicate species detected: {plant.species} in {plant.name}");
                continue;
            }
            dictionary.Add(plant.species, plant);
        }

        Catalog = new ReadOnlyDictionary<PlantSpecies, PlantDefinitionSO>(dictionary);
    }

    // Kaydetme işlemi
    public void SaveData()
    {
        // JSON'a dönüştür ve dosyaya kaydet
        string jsonData = JsonUtility.ToJson(this, true);
        File.WriteAllText(dataFilePath, jsonData);
        Debug.Log("PlantCatalog verisi kaydedildi.");
    }

    // Yükleme işlemi
    private void LoadData()
    {
        if (File.Exists(dataFilePath))
        {
            // Dosyayı oku ve JSON'dan veriyi çözümle
            string jsonData = File.ReadAllText(dataFilePath);
            JsonUtility.FromJsonOverwrite(jsonData, this);
            Debug.Log("PlantCatalog verisi başarıyla yüklendi.");
        }
        else
        {
            Debug.Log("Kaydedilmiş veriler bulunamadı. Yeni veri başlatılıyor.");
        }
    }
}


