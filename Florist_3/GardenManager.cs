using System.Collections.Generic;
using UnityEngine;

public class GardenManager : Singleton<GardenManager> 
{
    private List<PlantGrowth> activePlants = new List<PlantGrowth>();

    // Call when planting
    public void RegisterPlant(PlantGrowth plant) {
        activePlants.Add(plant);
    }

    // Call when harvesting/destroying
    public void UnregisterPlant(PlantGrowth plant) {
        activePlants.Remove(plant);
    }

    
}


