using UnityEngine;
using UnityEngine.UI;

public class SeedInventoryItem : MonoBehaviour {
    [SerializeField] private Image icon;
    [SerializeField] private Text quantityText;
    [SerializeField] private Button plant;

    private SeedStage _seed;
    private Species _species;
    private int _quantity;

    public void Setup(Species species,SeedStage seed) {
        _seed = seed;
        _species =species;
        icon.sprite = seed.sprite;
        
        quantityText.text = $"{_quantity}$";
    }

    
}