using UnityEngine;
using UnityEngine.UI;

public class SeedShopItem : MonoBehaviour {
    [SerializeField] private Image icon;
    [SerializeField] private Text nameText;
    [SerializeField] private Text priceText;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button plusButton;
    [SerializeField] private Button minusButton;

    private SeedStage _seed;
    private Species _species;

    public void Setup(Species species,SeedStage seed) {
        _seed = seed;
        _species =species;
        icon.sprite = seed.sprite;
        nameText.text = species.ToString();
        priceText.text = $"{seed.seedShopItem.purchasePrice}$";
    }
}