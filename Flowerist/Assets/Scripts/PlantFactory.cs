using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantFactory
{
    private Dictionary<PlantSpecies, Plant> plantPrototypes = new Dictionary<PlantSpecies, Plant>();

    // Prototipleri yükleyip, kopyalanabilir nesneler olarak saklıyoruz
    public void InitializePrototypes(PlantData[] plantDataArray)
    {
        foreach (var plantData in plantDataArray)
        {
            Plant plant = new Seed();

            if (plant != null)
            {
                plant.Initialize(plantData);
                plantPrototypes[plantData.plantSpecies] = plant; // Prototipi saklıyoruz
            }
        }
    }

    // Bitki nesnesi oluşturmak için prototipten kopyalama
    public Plant CreatePlant(PlantSpecies species)
    {
        if (plantPrototypes.TryGetValue(species, out Plant prototype)) {
            return (Plant)prototype.Clone();
        }
        Debug.LogError("Plant species not found in prototypes.");
        return null;
    }
}
