// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;
// using UnityEngine.Events;

// using UnityEngine;

// public class GardenBed : MonoBehaviour
// {
//     // ====== CORE COMPONENTS ======
//     private SpriteRenderer _soilRenderer;
//     private SpriteRenderer _plantRenderer;
//     private PlantData _currentPlant;
    
//     // ====== GROWTH STATE ======
//     private enum GrowthStage { Empty, SeedGrowing, Ready }
//     private GrowthStage _currentStage = GrowthStage.Empty;
//     private float _growthTimer;
//     private bool _isLocked = true;

//     void Awake()
//     {
//         _soilRenderer = GetComponent<SpriteRenderer>();
//         _plantRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>(); // Assumes plant is first child
//     }

//     void Update()
//     {
//         if (_currentStage == GrowthStage.SeedGrowing)
//         {
//             _growthTimer -= Time.deltaTime;
//             if (_growthTimer <= 0) SetStage(GrowthStage.Ready);
//         }
//     }

//     // ====== MAIN INTERACTION ======
//     public void Interact()
//     {
//         if (_isLocked) return;

//         switch (_currentStage)
//         {
//             case GrowthStage.Empty:
//                 PlantSeed();
//                 break;
//             case GrowthStage.Ready:
//                 Harvest();
//                 break;
//         }
//     }

   
//     private void PlantSeed()
//     {
        
//     }
//     private bool CanPlant(PlantData seed)
//     {
//         return seed.seed.requiredLevel <= GameManager.Instance.PlayerLevel;
//     }

//     private void StartGrowing()
//     {
//         if (_currentStage == GrowthStage.SeedGrowing)
//         {
//             _growthTimer = _currentPlant.sprout.growTime;
//             SetStage(GrowthStage.SeedGrowing);
//         }
//     }

//     private void Harvest()
//     {
//         ResetBed();
//     }

//     // ====== STATE MANAGEMENT ======
//     private void SetStage(GrowthStage newStage)
//     {
//         _currentStage = newStage;
//         UpdateVisuals();
//     }

//     private void ResetBed()
//     {
//         _currentPlant = null;
//         SetStage(GrowthStage.Empty);
//     }

//     // ====== VISUAL UPDATES ======
//     private void UpdateVisuals()
//     {
//         _plantRenderer.enabled = _currentStage != GrowthStage.Empty;

//         switch (_currentStage)
//         {
//             case GrowthStage.Empty:
//                 _soilRenderer.sprite = Resources.Load<Sprite>("Sprites/Soil/EmptySoil");
//                 _plantRenderer.sprite = null;
//                 break;
//             case GrowthStage.SeedGrowing:
//                 _soilRenderer.sprite = Resources.Load<Sprite>("Sprites/Soil/SeedSoil");
//                 _plantRenderer.sprite = _currentPlant.seed.seedSprite;
//                 break;
            
//             case GrowthStage.Ready:
//                 _plantRenderer.sprite = _currentPlant.flower.flowerSprite;
//                 break;
//         }
//     }

//     // ====== PUBLIC CONTROLS ======
//     public void Unlock() => _isLocked = false;
//     public bool IsReadyToHarvest => _currentStage == GrowthStage.Ready;
//     public bool IsEmpty => _currentStage == GrowthStage.Empty;
// }


