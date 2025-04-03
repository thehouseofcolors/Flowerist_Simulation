using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantDefinition", menuName = "Plants/PlantDefinition", order = 2)]
public class PlantDataSO: ScriptableObject
{
    public Species species;
    
    [Header("Stages")]
    public SeedStage seedStage;
    public GrowingStage growingStage;
    public FlowerStage flowerStage;


}