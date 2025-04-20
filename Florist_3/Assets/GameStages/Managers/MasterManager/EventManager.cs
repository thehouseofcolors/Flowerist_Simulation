using UnityEngine.Events;
using UnityEngine;
using System;

public class EventManager : Singleton<EventManager>
{
    // Button-triggered events
    public static event Action OnLevelUpdate;
    public static event Action OnMoneyChanged;
    public static event Action<PlantDataSO, int> OnSeedPurchaseRequested;
    public static event Action<Species ,int> OnSeedInventoryUpdate;

    //purchase button tetikliyor
    public static void RequestSeedPurchase(PlantDataSO plant,int purchaseQuantity)
    {
        OnSeedPurchaseRequested?.Invoke(plant, purchaseQuantity);
    }
    
    //economy manager tetikliyor    
    public static void UpdateSeedInventory(PlantDataSO plant,int quantityChange)
    {
        OnSeedInventoryUpdate?.Invoke(plant.species,quantityChange);
        OnMoneyChanged?.Invoke();
    }

    
    
    //later
    public static event Action<Species, FlowerStage> OnFlowerSellRequested;
    
    public static void RequestFlowerSale(Species species,FlowerStage flower) {
        OnFlowerSellRequested?.Invoke(species,flower);
    }
    
    
    
    // public UnityEvent<Species, SeedStage> _OnSeedPurchaseRequested;
    // public UnityEvent<Species, FlowerStage> _OnFlowerSellRequested;

    // Existing economy events
    // public UnityEvent<int> _OnMoneyChanged;

    // Fire methods for buttons



}

