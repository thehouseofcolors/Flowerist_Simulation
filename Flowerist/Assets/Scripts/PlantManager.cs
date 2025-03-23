using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    [SerializeField] private List<PlantData> plantDataList = new List<PlantData>(); // Inspector'den atanabilir
    private Dictionary<PlantSpecies, PlantData> plantInventory = new Dictionary<PlantSpecies, PlantData>();

    public Dictionary<PlantSpecies, PlantData> PlantInventory => plantInventory; // Dışarıdan erişim için

    void Awake()
    {
        LoadPlantData();
    }

    // Bitki verilerini yükleme fonksiyonu
    void LoadPlantData()
    {
        // Inspector üzerinden eklenenleri ekle
        foreach (var plantData in plantDataList)
        {
            AddPlantToInventory(plantData);
        }

        // Eğer Inspector üzerinden ekleme yoksa Resources klasöründen yükle
        if (plantInventory.Count == 0)
        {
            PlantData[] plantDataArray = Resources.LoadAll<PlantData>("PlantData");
            foreach (var plantData in plantDataArray)
            {
                AddPlantToInventory(plantData);
            }
        }

        Debug.Log($"Plant data loaded successfully. Total Plants: {plantInventory.Count}");
    }

    // Bitkiyi envantere ekleme fonksiyonu (Tekrar eklemeyi önler)
    private void AddPlantToInventory(PlantData plantData)
    {
        if (plantData == null)
        {
            Debug.LogWarning("Null PlantData detected!");
            return;
        }

        if (!plantInventory.ContainsKey(plantData.plantSpecies))
        {
            plantInventory[plantData.plantSpecies] = plantData;
        }
        else
        {
            Debug.LogWarning($"Duplicate PlantData detected: {plantData.plantSpecies}");
        }
    }

    // Dışarıdan belirli bir bitki türünün verisini almak için fonksiyon
    public PlantData GetPlantData(PlantSpecies species)
    {
        if (plantInventory.TryGetValue(species, out PlantData plantData))
        {
            return plantData;
        }
        Debug.LogWarning($"Plant species not found: {species}");
        return null;
    }
}
