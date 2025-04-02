using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TMP_Text quantityText;
    private int _quantity;
    private int _currentQuantity
    {
        get
        {
            return _quantity;
        }
        set
        {
            // Eğer yeni değer 0'dan küçükse, 0 atanır
            if (value < 0)
            {
                _quantity = 0;
                Debug.LogWarning("Quantity cannot be less than 0. Setting to 0.");
            }
            else
            {
                _quantity = value;
            }
        }
    }

    private PlantSpecies species;

    // void OnEnable()
    // {
    //     GameManager.Instance.seedInventory.OnInventoryChanged += UpdateQuantityUI;
    // }
    // void OnDisable()
    // {
    //     GameManager.Instance.seedInventory.OnInventoryChanged -= UpdateQuantityUI;
    
    // }
    public void InitializeItem(PlantSpecies _species, PlantDefinitionSO plantDefinition)
    {
        species = _species;
        icon.sprite = plantDefinition.seedData.packIcon;
        quantityText.text = $"{_currentQuantity}";
    }
    public void UpdateQuantityUI(PlantSpecies _species, int _changeAmount)
    {
        if(species != _species) return;
        _currentQuantity += _changeAmount;
        UpdateVisibility();
        Debug.Log("event is listening");
        quantityText.text = $"{_currentQuantity}";
        
    }
    
    void UpdateVisibility()
    {
        if(_currentQuantity<1)
        {
            this.gameObject.SetActive(false);
        }else{
            this.gameObject.SetActive(true);
            
        }
    }

}
