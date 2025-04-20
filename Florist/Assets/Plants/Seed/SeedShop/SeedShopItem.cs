using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class SeedShopItem : MonoBehaviour
{
    // UI Elements (assigned in Prefab Inspector)
    public GameObject LockedSeedShopItemPrefab;
    public GameObject SeedShopItemPrefab; //this is just a component of the prefab, will be assigned when instantiate the prefab
    public Image seedShopSprite;//this is just a component of the prefab, will be assigned when instantiate the prefab
    public Button purchaseButton;
    public Button plusButton;
    public Button minusButton;
    public TMP_Text seedNameText; //this is just a component of the prefab, will be assigned when instantiate the prefab
    public TMP_Text quantityText; 
    public TMP_Text priceText;//this is just a component of the prefab, will be assigned when instantiate the prefab
    public TMP_Text totalPriceText;
    public TMP_Text requiredLevelText;//this is just a component of the prefab, will be assigned when instantiate the prefab

    // Data (can be modified at runtime)
    public int CurrentQuantity { get; private set; }
    public int Price { get; private set; }

    // Initialize (call this in Awake() or when instantiating the prefab)
    public void SetupLocked(int requiredLevel)
    {
        LockedSeedShopItemPrefab.SetActive(true);
        SeedShopItemPrefab.SetActive(false);
        requiredLevelText.text = $"Required Level: {requiredLevel}";

    }
    public void Setup(Sprite sprite,int basePrice)
    {
        SeedShopItemPrefab.SetActive(true);
        LockedSeedShopItemPrefab.SetActive(false);
        seedShopSprite.sprite = sprite;
        Price = basePrice;
        priceText.text = $"Price: {Price}";
        seedNameText.text = sprite.name;
        purchaseButton.onClick.AddListener(Purchase);
        plusButton.onClick.AddListener(IncreaseQuantity);
        minusButton.onClick.AddListener(DecreaseQuantity);
        UpdateUI();
    }

    private void Purchase() { /* Handle purchase logic */ }
    private void IncreaseQuantity() { CurrentQuantity++; UpdateUI(); }
    private void DecreaseQuantity() { CurrentQuantity--; UpdateUI(); }

    private void UpdateUI()
    {
        Debug.Log("UpdateUI called");
        quantityText.text = $"{CurrentQuantity}";
        
        totalPriceText.text = $"total price: {CurrentQuantity * Price}";
    }
}