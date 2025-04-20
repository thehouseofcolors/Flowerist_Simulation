using System;
using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;

#region Plant Stages Data
[Serializable]
public class SeedStageData
{
    [Header("Visuals")]
    public Sprite packIcon;
    
    [Header("Inventory")]
    [Range(1, 100)] public int seedsPerPack = 10;
    
    [Header("Commerce")]
    [Range(10, 1000)] public int purchasePrice = 50;
    [Range(1, 50)] public int requiredLevel = 1;
}

[Serializable]
public class SproutStageData
{
    public Sprite normalSprite;
    public Sprite harvestReadySprite;
}

[Serializable]
public class FlowerStageData
{
    public Sprite normalSprite;
    [Range(1, 100)] public int sellPrice = 20;
}
#endregion