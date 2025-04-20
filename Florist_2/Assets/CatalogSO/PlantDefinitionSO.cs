using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantDefinition", menuName = "Plants/PlantDefinition", order = 2)]
public class PlantDefinitionSO: ScriptableObject
{
    public string displayName;
    public PlantSpecies species;
    
    [Header("Growth Stages")]
    public SeedStageData seedData;
    public SproutStageData sproutData;
    public FlowerStageData flowerData;
    
    [Header("Growth Parameters")]
    public PlantGrowthSettings growthSettings;

    public void OnValidate()
    {
        if (string.IsNullOrEmpty(displayName))
        {
            displayName = species.ToString();
        }
    }
}
