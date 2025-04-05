using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedShopItem : MonoBehaviour 
{
    #region UI
    [Header("UI elements")]
    [SerializeField] private GameObject lockedSeedPrefab;
    [SerializeField] private TMP_Text requiredLevelText;
    [SerializeField] private GameObject unlockedSeedPrefab;
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text packSizeText;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text totalPriceText;
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button plusButton;
    [SerializeField] private Button minusButton;
    #endregion
    #region GameObject 
    int requiredLevel;
    int price;
    int packSize;
    private SeedStage _seed;
    private Species _species;
    int quantity = 0;
    int maxQuantity = 100;
    #endregion
    
    public void OnEnable()
    {
        EventManager.OnLevelUpdate += HandleLevel;
    }

    public void OnDisable()
    {
        EventManager.OnLevelUpdate -= HandleLevel;

        
    }

    public void HandleLevel()
    {
        if(requiredLevel > DataManager.Level) return;
        unlockedSeedPrefab.SetActive(true);
        lockedSeedPrefab.SetActive(false);
        UpdateUI();
        SetButtons();
    }
    public void Setup(Species species,SeedStage seed) 
    {
        _species = species;
        _seed = seed;
        requiredLevel =_seed.seedShopItem.requiredLevel;
        price = _seed.seedShopItem.purchasePrice;
        packSize = _seed.seedShopItem.seedsPerPack;

        nameText.text = _species.ToString();        
        requiredLevelText.text =$"requiredLevel {requiredLevel}";
        packSizeText.text =$"{packSize} per pack";
        icon.sprite = _seed.sprite;


        if(requiredLevel > DataManager.Level)
        {
            lockedSeedPrefab.SetActive(true);
            unlockedSeedPrefab.SetActive(false);
            return;
        }
        HandleLevel();
    }
   
    

    public void UpdateUI()
    {
        priceText.text = $"Price: {price}$";
        totalPriceText.text =$"Total: {price*quantity}$";
        quantityText.text = $"{quantity}";
    }
    public void OnQuantityChange(int change)
    {
        quantity = Mathf.Clamp(quantity + change,0,maxQuantity);
        UpdateUI();
    }
    public void OnPurchaseButtonClick()
    {
        EventManager.RequestSeedPurchase(_species, _seed, quantity);
        quantity = 0;
        quantityText.text = $"{quantity}";
    }
    public void SetButtons()
    {
        plusButton.onClick.AddListener( () => OnQuantityChange(1));
        minusButton.onClick.AddListener(() => OnQuantityChange(-1));
        buyButton.onClick.AddListener(OnPurchaseButtonClick);

        // minusButton.interactable = quantity >0;
        // buyButton.interactable = quantity>0;
    }

    private void OnDestroy()
    {
        // Clean up event listeners
        plusButton.onClick.RemoveAllListeners();
        minusButton.onClick.RemoveAllListeners();
        buyButton.onClick.RemoveAllListeners();
    }
    
}

