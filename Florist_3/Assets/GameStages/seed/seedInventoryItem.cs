using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedInventoryItem : MonoBehaviour 
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Button plant;
    private PlantDataSO _plant;
    public int InventoryQuantity = 0;
    public Species _species;
    
    public void SetInventoryQuantity(int newQuntity)
    {
        InventoryQuantity = newQuntity;
    }
    public void OnEnable()
    {
        EventManager.OnSeedInventoryUpdate += HandleInventoryChange;
    }
    public void OnDisable()
    {
        EventManager.OnSeedInventoryUpdate -= HandleInventoryChange;
    }
    public void Setup(PlantDataSO plant, int purchaseQuantity) 
    {
        _plant=plant;
        _species =_plant.species;
        
        icon.sprite = _plant.seedStage.sprite;
        SetInventoryQuantity(purchaseQuantity);
        quantityText.text = $"{InventoryQuantity}";
    }
    public void HandleInventoryChange(Species species,int quantityChange)
    {
        if(species != _species) return;
        quantityText.text = $"{InventoryQuantity}$";
    }

    
}