
using System;
using UnityEngine;

[Serializable]
public class SeedStage
{
    public Species species;
    public Sprite sprite;
    public SeedShopData seedShopItem;
}


[Serializable]
public class SeedShopData
{
    
    [Header("Inventory")]
    [Range(1, 100)] public int seedsPerPack = 10;
    
    
    [Header("Commerce")]
    [Range(10, 1000)] public int purchasePrice = 50;
    [Range(1, 50)] public int requiredLevel = 1;

    
    
}

