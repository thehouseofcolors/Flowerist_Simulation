using System;
using UnityEngine;

[Serializable]
public class FlowerStage
{
    public Species species;
    public Sprite icon;
    
    [Range(1, 100)] public int sellPrice = 20;
    public int xpReward = 3;
}