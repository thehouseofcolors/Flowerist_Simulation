using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NormalSeedPanel : MonoBehaviour
{
    public InventoryManager inventoryManager;  // Envanter yöneticisi

    public TextMeshProUGUI seedNameText;
    
    public Image seedImage;
    public Button plusButton;
    public Button minusButton;
    public Button buyButton;
    public TextMeshProUGUI quantityText;
    
    private int quantity = 0;
    private PlantData plant;

    // Bu fonksiyon, panelin bilgilerini ve butonları yapılandırmak için kullanılacak
    public void InitializePanel(PlantData plantData)
    {
        inventoryManager= FindObjectOfType<InventoryManager>();
        plant = plantData;
        seedNameText.text = plant.plantSpecies.ToString();
        seedImage.sprite = plant.seed.seedSprite;
        quantityText.text = quantity.ToString();

        // Artı ve Eksi butonları işlevsellik ekleyelim
        plusButton.onClick.AddListener(() => ChangeQuantity(1));
        minusButton.onClick.AddListener(() => ChangeQuantity(-1));

        // Satın alma butonuna işlevsellik ekleyelim
        buyButton.onClick.AddListener(BuySeed);
    }

    // Adeti artırmak ve azaltmak için fonksiyon
    private void ChangeQuantity(int amount)
    {
        quantity = Mathf.Max(0, quantity + amount); // Adet negatif olamaz
        quantityText.text = quantity.ToString();
    }

    // Satın alma işlemi
    private void BuySeed()
    {
        inventoryManager.AddSeed(plant, quantity);  // Tohum envantere ekleniyor
        Debug.Log($"{plant.plantSpecies} satın alındı! Adet: {quantity}");
        quantity = 0; // Satın alındıktan sonra adeti sıfırlayalım
        quantityText.text = quantity.ToString();
    }
    
}
