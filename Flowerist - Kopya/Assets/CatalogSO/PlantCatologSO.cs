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
    public Dictionary<PlantSpecies, PlantDefinitionSO> Catalog;
    


    private void OnEnable()
    {
        InitializeLookup();
    }
    public PlantDefinitionSO GetPlantBySpecies(PlantSpecies species)
    {
        return Catalog.TryGetValue(species, out var plant) ? plant : null;
    }

    //ReadOnly Directory yapar
    private void InitializeLookup()
    {
        if (Catalog != null) return; // Eğer zaten başlatıldıysa, tekrar başlatma.

        Catalog = new Dictionary<PlantSpecies, PlantDefinitionSO>();
        foreach (var plant in plants)
        {
            if (plant == null) continue;

            if (Catalog.ContainsKey(plant.species))
            {
                Debug.LogError($"Duplicate species detected: {plant.species} in {plant.name}");
                continue;
            }
            Catalog.Add(plant.species, plant);
        }

    }

    
}


