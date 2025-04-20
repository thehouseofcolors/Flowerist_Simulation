
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllPlants", menuName = "AllPlants", order = 1)]
public class AllPlants : ScriptableObject
{
    [SerializeField] public List<PlantData> allPlants = new List<PlantData>();
    
    // Read-only public access
    public IReadOnlyList<PlantData> GetAllPlants => allPlants.AsReadOnly();

    #if UNITY_EDITOR
    private void OnValidate()
    {
        // Ensure no duplicate plant species
        var uniqueSpecies = new HashSet<PlantSpecies>();
        foreach (var plant in allPlants)
        {
            if (plant != null && !uniqueSpecies.Add(plant.Species))
            {
                Debug.LogWarning($"Duplicate plant species found: {plant.Species}");
            }
        }
    }
    #endif
}
