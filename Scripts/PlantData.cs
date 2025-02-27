using System;
using UnityEngine;

#region enumTanımları
public enum PlantStates{Seed, Sprout, Flower}
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

#region BitkiDurumları
[Serializable] public struct SeedState
{
    public Sprite seedSprite;
    public int seedCost;
    public int requiredLevel;

}
[Serializable]public struct SproutState{
    public enum CurrentState{Planted, Growing, Harvastable, Rotten}
    
    public Sprite sproutSprite;

    // public int growingField; //ilerde ağaaç benzeri şeyler eklemek istiyorum bunların ekim alanları daha büyük olsun
    public int growTime;  
    public int maxHarvestWaitTime;//growingden sonra başlıyor eğer harvast yapılmazsa rotten

    //growing timeı başlatmak için gerekli
    public int initialWaterNeeded;
    public int fertilizerNeeded;

    //growing süresince harcanıyor
    public int electricityPerSecond;
    public int waterNeededPerSecond;    
}
[Serializable]public struct FlowerState
{
    public Sprite flowerSprite; // Çiçeğin görseli
    public int sellPrice; 
}

#endregion



[CreateAssetMenu(fileName = "NewFlower", menuName = "Flower/Create New Flower")]
public class PlantData : ScriptableObject
{
    
    public string plantName;   
    public PlantSpecies plantSpecies; 
    public SeedState seed;
    public SproutState sprout;
    public FlowerState flower;


    
}
