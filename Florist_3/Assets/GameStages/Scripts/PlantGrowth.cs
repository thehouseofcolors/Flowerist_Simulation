// using UnityEngine;

// public class PlantGrowth : MonoBehaviour {
//     public SeedData SeedData { get; private set; }
//     private float growthTimer;

//     public void Initialize(SeedData seed, float timeRemaining = -1) {
//         SeedData = seed;
//         growthTimer = timeRemaining > 0 ? SeedData.growTime - timeRemaining : 0;
//         GardenManager.Instance.RegisterPlant(this);
//     }

//     public float GetRemainingTime() {
//         return Mathf.Max(0, SeedData.growTime - growthTimer);
//     }

//     void Update() {
//         growthTimer += Time.deltaTime;
//         if (growthTimer >= SeedData.growTime) {
//             Harvest();
//         }
//     }

//     void Harvest() {
//         InventoryManager.Instance.AddFlower(SeedData.flowerOutput);
//         GardenManager.Instance.UnregisterPlant(this);
//         Destroy(gameObject);
//     }

//     void OnDestroy() {
//         if (GardenManager.Instance != null) {
//             GardenManager.Instance.UnregisterPlant(this);
//         }
//     }
// }