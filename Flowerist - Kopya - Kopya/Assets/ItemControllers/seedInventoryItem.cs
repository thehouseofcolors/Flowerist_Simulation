using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedInventoryItem : MonoBehaviour {
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Button plant;

    private SeedStackData _seedStack;
    private Species _species;

    public void OnEnable()
    {
        EventManager.OnSeedInventoryUpdate += HandleInventoryChange;
    }
    public void OnDisable()
    {
        EventManager.OnSeedInventoryUpdate -= HandleInventoryChange;
    }
    public void Setup(Species species,SeedStage seed, int purchaseQuantity) 
    {
        _species =species;
        _seedStack = seed.seedStackData;
        icon.sprite = seed.sprite;
        _seedStack.StackQuantity = purchaseQuantity;
        quantityText.text = $"{_seedStack.StackQuantity}";
    }
    public void HandleInventoryChange(Species species,int quantityChange)
    {
        if(species != _species) return;
        quantityText.text = $"{_seedStack.StackQuantity}$";
    }

    
}