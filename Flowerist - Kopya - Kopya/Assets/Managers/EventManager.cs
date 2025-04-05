using UnityEngine.Events;
using UnityEngine;
using System;

public class EventManager : Singleton<EventManager>
{
    // Button-triggered events
    public static event Action OnLevelUpdate;
    public static event Action<int> OnMoneyChanged;
    public static event Action<Species,SeedStage, int> OnSeedPurchaseRequested;
    public static event Action<Species ,int> OnSeedInventoryUpdate;

    //later
    public static event Action<Species, FlowerStage> OnFlowerSellRequested;
    
    
    
    // public UnityEvent<Species, SeedStage> _OnSeedPurchaseRequested;
    // public UnityEvent<Species, FlowerStage> _OnFlowerSellRequested;

    // Existing economy events
    // public UnityEvent<int> _OnMoneyChanged;

    // Fire methods for buttons

    //purchase button tetikliyor
    public static void RequestSeedPurchase(Species species,SeedStage seed,int purchaseQuantity)
    {
        OnSeedPurchaseRequested?.Invoke(species,seed, purchaseQuantity);
    }
    
    public static void RequestFlowerSale(Species species,FlowerStage flower) {
        OnFlowerSellRequested?.Invoke(species,flower);
    }
    
    //economy manager tetikliyor    
    public static void UpdateSeedInventory(Species species,int quantityChange)
    {
        OnSeedInventoryUpdate?.Invoke(species,quantityChange);
    }


}

