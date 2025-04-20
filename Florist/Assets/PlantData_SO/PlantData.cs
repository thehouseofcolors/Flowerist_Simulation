using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

#region Enums
public enum PlantStates { Seed, Sprout, Flower }
public enum PlantSpecies
{
    Daisy,
    Rose,
    Tulip,
    Sunflower,
    Orchid,
    Lily,
    Lavender,
    Violet,
    Chamomile,
    Jasmine
}
#endregion

#region Plant State Structs
[Serializable]
public struct SeedPackState
{
    public Sprite seedPackSprite;
    [Min(1)] public int seedPackSize;
    [Min(0)] public int seedPackPrice;
    [Min(1)] public int requiredLevel;
}

[Serializable]
public struct GrowthNeeds
{
    [Min(1)] public int waterNeeded;
    [Min(0)] public int fertilizerNeeded;
    [Min(0)] public int electricityPerSecond;
    [Min(0)] public int waterNeededPerSecond;
    [Min(1), Tooltip("Time in seconds")] public int growTime;
    [Min(1), Tooltip("Time in seconds after which plant rots")] public int maxHarvestWaitTime;
    [Min(1)] public int initialWaterNeeded;
}

[Serializable]
public struct SproutPotState
{
    public enum CurrentState { Growing, Harvestable, Rotten }
    
    public GrowthNeeds growthNeed;
    public CurrentState currentState;
    public Sprite sproutSprite;
    public Sprite HarvestableSprite;
    public Sprite rottenSprite;
    [Min(1)] public int potSize;
    [Min(0)] public int potPrice;
}

[Serializable]
public struct FlowerState
{
    public Sprite flowerSprite;
    public Sprite wiltedSprite;
    [Min(0)] public int sellPrice;
    public bool isFresh;
    [Min(1), Tooltip("Time in seconds before flower wilts")] public int maxWaitTime;
}
#endregion

[CreateAssetMenu(fileName = "NewFlower", menuName = "Flower/Create New Flower")]
public class PlantData : ScriptableObject
{
    public PlantSpecies Species;
    public string Name;
    
    [Header("Plant States")]
    public SeedPackState seed;
    public SproutPotState sprout;
    public FlowerState flower;


#if UNITY_EDITOR
    private void OnValidate()
    {
        // Automatically set name to match species
        if (string.IsNullOrEmpty(Name))
        {
            Name = Species.ToString();
        }

        // Validate that harvest wait time makes sense compared to grow time
        if (sprout.growthNeed.maxHarvestWaitTime <= sprout.growthNeed.growTime)
        {
            Debug.LogWarning($"Harvest wait time should be greater than grow time for {Name}");
        }

        // Ensure initial water needed isn't more than total water needed
        if (sprout.growthNeed.initialWaterNeeded > sprout.growthNeed.waterNeeded)
        {
            Debug.LogWarning($"Initial water needed exceeds total water needed for {Name}");
        }
    }

    [ContextMenu("Set Default Name")]
    private void SetDefaultName()
    {
        Name = Species.ToString();
        EditorUtility.SetDirty(this);
    }

    [MenuItem("Tools/Validate All Plant Data")]
    private static void ValidateAllPlantData()
    {
        var guids = AssetDatabase.FindAssets("t:PlantData");
        foreach (var guid in guids)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var plantData = AssetDatabase.LoadAssetAtPath<PlantData>(path);
            
            try 
            {
                UnityEditor.EditorUtility.SetDirty(plantData);
                Debug.Log($"Validated: {plantData.Name}", plantData);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to validate {path}: {e.Message}");
            }
        }
        
        AssetDatabase.SaveAssets();
        Debug.Log($"Validated {guids.Length} plant data assets");
    }
#endif
}