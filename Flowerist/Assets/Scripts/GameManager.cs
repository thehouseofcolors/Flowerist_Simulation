using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class InventoryEventSystem
{
    public static event System.Action<InventoryType, PlantData, int> OnInventoryChanged;
    
    public static void NotifyChange(InventoryType type, PlantData plant, int delta)
    {
        OnInventoryChanged?.Invoke(type, plant, delta);
    }
}
public class GameManager : Singleton<GameManager>  
{   
    [SerializeField] public AllPlants AllPlantsSO; // Reference to the ScriptableObject
    
    protected override void Awake()
    {
        base.Awake(); // Ensure Singleton behavior is applied
        
    }
    
}  