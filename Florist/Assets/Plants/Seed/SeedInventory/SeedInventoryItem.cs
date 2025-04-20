using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SeedInventoryItem : MonoBehaviour
{
    public Image seedInventorySprite; //this is just a component of the prefab, will be assigned when instantiate the prefab
    
    public TextMeshProUGUI quantityText; //this is just a component of the prefab, will be assigned when instantiate the prefab
     //this is just a component of the prefab, will be assigned when instantiate the prefab

    public void SetUp(Sprite sprite, int quantity)
    {
        seedInventorySprite.sprite = sprite;
        quantityText.text = $"{quantity}";
    }

#region further implementation

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        
        Vector3 dropPos = Camera.main.ScreenToWorldPoint(eventData.position);
        if (IsValidDropPosition(dropPos)) 
        {
            HandleSuccessfulPlanting(dropPos);
        }
    }
    private bool IsValidDropPosition(Vector3 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero, 
            Mathf.Infinity, LayerMask.GetMask("Soil"));
        return hit.collider != null;
    }
    private void HandleSuccessfulPlanting(Vector3 dropPosition)
    {
        // if (InventorySystem.Instance.TryUseSeed(seedType)) 
        // {
        //     PlantManager.Instance.SpawnPlant(seedType, dropPosition);
        //     UpdateQuantityDisplay();
        // }
    }
#endregion
}