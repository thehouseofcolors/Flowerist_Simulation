using System;
using UnityEngine;
using UnityEngine.Serialization;

#region Growth Systems
[Serializable]
public class PlantGrowthSettings
{
    
    
    [Header("Requirements")]
    [Range(1, 10)] public int requiredPotSize = 1;
    
    [Header("Initial Needs")]
    [Range(1, 100)] public int initialWater = 30;
    [Range(0, 50)] public int initialFertilizer = 10;
    
    [Header("Ongoing Needs")]
    [Range(0, 10)] public int electricityPerSecond = 1;
    [Range(0, 20)] public int waterPerSecond = 2;
    [Range(0, 5)] public int fertilizerPerSecond = 1;
    
    [Header("Timings")]
    [Range(10, 3600)] public int growTimeSeconds = 600;
}



public enum GrowthState { Growing, Harvestable, Rotten }
#endregion