// using UnityEngine;
// using UnityEngine.EventSystems;

// public class PlantingZone : MonoBehaviour, IDropHandler
// {
//     public bool isLocked = false;
//     public Plant currentPlant;
    
//     public void OnDrop(PointerEventData eventData)
//     {
//         if (isLocked) return;
        
//         DraggableSeed seed = eventData.pointerDrag.GetComponent<DraggableSeed>();
//         if (seed != null && InventoryManager.Instance.RemoveSeed(seed.plantData, 1))
//         {
//             currentPlant = PlantFactory.Instance.CreatePlant(seed.plantData.plantSpecies);
//             StartCoroutine(GrowPlant());
//         }
//     }

//     IEnumerator GrowPlant()
//     {
//         yield return new WaitForSeconds(currentPlant.plantData.sprout.growTime);
//         currentPlant.AdvanceState(); // Seed → Sprout
//         // Add visual feedback here
//     }
//     public void Harvest()
// {
//     if (currentPlant.currentState == PlantStates.Flower)
//     {
//         InventoryManager.Instance.AddFlower(currentPlant.plantData);
//         Destroy(currentPlant.gameObject);
//     }
// }

//     public void LockZone()
//     {
//         isLocked = true;
//     }

//     public void UnlockZone()
//     {
//         isLocked = false;
//     }
// }