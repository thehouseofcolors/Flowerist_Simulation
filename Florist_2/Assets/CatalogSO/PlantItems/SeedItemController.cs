using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedItemController : MonoBehaviour
{
    #region UIRef
    // UI References
    [Header("UI References")]
    [SerializeField] private GameObject lockedItemUI;
    [SerializeField] private GameObject unlockedItemUI;
    [SerializeField] private Image seedIcon;
    [SerializeField] private TMP_Text seedNameText;
    [SerializeField] private TMP_Text seedPackSize;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private TMP_Text totalPriceText;
    [SerializeField] private TMP_Text requiredLevelText;
    [SerializeField] private Button purchaseButton;
    [SerializeField] private Button plusButton;
    [SerializeField] private Button minusButton;

    #endregion
    // Data

    #region seedData
    private PlantDefinitionSO _plant;
    private int _quantity;
    private int _purchaseQuantity
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
    private int _price;
    private int _requiredLevel;

    #endregion
    void OnEnable()
    {
        GameManager.OnLevelChange += UnlockItem;
    }
    void OnDisable()
    {
        GameManager.OnLevelChange -= UnlockItem;
    }
    // Initialization
    public void InitializeData(PlantDefinitionSO plant, int playerLevel)
    {
        _plant = plant;
        _price = plant.seedData.purchasePrice;
        _requiredLevel = plant.seedData.requiredLevel;
        if (playerLevel < _requiredLevel)
        {
            ShowLockedState();
        }
        else
        {
            ShowUnlockedState();
        }
        
    }
    
    public void UnlockItem(int playerLevel)
    {
        if (playerLevel < _requiredLevel)
        {
            return;
        }
        else
        {
            ShowUnlockedState();
        }

    }


    private void ShowLockedState()
    {
        lockedItemUI.SetActive(true);
        unlockedItemUI.SetActive(false);
        requiredLevelText.text = $"Lv. {_requiredLevel}";
    }

    private void ShowUnlockedState()
    {
        lockedItemUI.SetActive(false);
        unlockedItemUI.SetActive(true);

        seedIcon.sprite = _plant.seedData.packIcon;
        seedNameText.text = _plant.displayName;
        seedPackSize.text = $"{_plant.seedData.seedsPerPack} seed per pack";
        priceText.text = $"{_price} coins";
        SetupButtons();
        UpdateUI();
    }
    void SetupButtons()
    {
        purchaseButton.onClick.AddListener(OnPurchaseButtonPressed);
        plusButton.onClick.AddListener(IncreaseQuantity);
        minusButton.onClick.AddListener(DecreaseQuantity);
    }
    // Quantity Management
    private void IncreaseQuantity() { _purchaseQuantity++; UpdateUI(); }
    private void DecreaseQuantity() { _purchaseQuantity--; UpdateUI(); }


    private void UpdateUI()
    {
        quantityText.text = _purchaseQuantity.ToString();
        totalPriceText.text = $"{_purchaseQuantity * _price} coins";
        purchaseButton.interactable = _purchaseQuantity > 0;
    }

    // Purchase Logic
    public void OnPurchaseButtonPressed()
    {
        Debug.Log($"purchace button cliced");
        PurchaseHandler.Instance.PurchaseItem(_plant, _purchaseQuantity);
        _purchaseQuantity = 0;
        UpdateUI();
    }
    void OnDestroy()
    {
        purchaseButton.onClick.RemoveListener(OnPurchaseButtonPressed);
        plusButton.onClick.RemoveListener(IncreaseQuantity);
        minusButton.onClick.RemoveListener(DecreaseQuantity);
    }

}