using System.Collections.Generic;
using UnityEngine;
using System;


#region Growth Systems
[Serializable]
public class GrowthNeeds
{
    [Header("Requirements")]
    [Range(1, 10)] public int requiredPotSize = 1;
    [Range(1, 10)] public int seedPerPot = 10;
    
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
#endregion

[Serializable]
public class GrowingStage
{
    public Species species;
    public Sprite harvestReadySprite;
    public GrowthNeeds growthNeeds;

    [Header("Effects")]
    public ParticleSystem growthParticles;
    public ParticleSystem harvestParticles;
    public AudioClip growthSound;
}

