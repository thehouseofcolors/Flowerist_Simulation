using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct InventoryItem
{
    public PlantSpecies species;
    public Sprite sprite;
    public int inventoryQuantity;
    
    public InventoryItem(PlantSpecies _species, Sprite _sprite, int _inventoryQuantity)
    {
        species = _species;
        sprite = _sprite;
        inventoryQuantity = _inventoryQuantity;
    }

}

public class InventoryItemController : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TMP_Text quantityText;
    

    InventoryItem inventoryItem;   

    void OnEnable()
    {
        PurchaseHandler.OnSeedInventoryChanged += HandleInventoryChanges;
    }
    void OnDisable()
    {
        PurchaseHandler.OnSeedInventoryChanged -= HandleInventoryChanges;
        
    }
    public void HandleInventoryChanges(PlantSpecies _species, int _purchaseQuantity)
    {
        if(inventoryItem.species != _species) return;
        UpdateQuantity(_purchaseQuantity);
        
    }
    
    public void InitializeItem(PlantDefinitionSO plantDefinition)
    {
        inventoryItem = new InventoryItem
        (
            plantDefinition.species,
            plantDefinition.seedData.packIcon,
            0
        );
        icon.sprite = inventoryItem.sprite;
        
    }
    
    public void UpdateQuantity( int _changeAmount)
    {
        inventoryItem.inventoryQuantity +=_changeAmount;
        UpdateUI();
        
    }
    
    
    void UpdateUI()
    {
        quantityText.text = $"{inventoryItem.inventoryQuantity}";
    }

    //RemoveItem() tanımla

}
