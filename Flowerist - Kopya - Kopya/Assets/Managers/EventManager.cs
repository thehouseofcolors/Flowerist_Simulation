using UnityEngine.Events;
using UnityEngine;
using System;

public class EventManager : Singleton<EventManager>
{
    // Button-triggered events
    public static event Action<SeedStage> OnSeedPurchaseRequested;
    public static event Action<FlowerStage> OnFlowerSellRequested;
    public UnityEvent<SeedStage> _OnSeedPurchaseRequested;
    public UnityEvent<FlowerStage> _OnFlowerSellRequested;

    // Existing economy events
    public static event Action<int> OnMoneyChanged;
    public UnityEvent<int> _OnMoneyChanged;

    // Fire methods for buttons
    public static void RequestSeedPurchase(SeedStage seed) {
        OnSeedPurchaseRequested?.Invoke(seed);
    }
    
    public static void RequestFlowerSale(FlowerStage flower) {
        OnFlowerSellRequested?.Invoke(flower);
    }
    
}

// public class ShopButton : MonoBehaviour
// {
//     [SerializeField] SeedStage seedData;
//     [SerializeField] Button button;

//     void Start()
//     {
//         button.onClick.AddListener(() => {
//             EventManager.RequestSeedPurchase(seedData);
//         });
//     }
// }

// public class SellButton : MonoBehaviour
// {
//     [SerializeField] FlowerStage flowerData;
//     [SerializeField] Button button;

//     void Start()
//     {
//         button.onClick.AddListener(() => {
//             EventManager.RequestFlowerSale(flowerData);
//         });
//     }
// }

