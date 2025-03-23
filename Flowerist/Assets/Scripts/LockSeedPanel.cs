using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LockedSeedPanel : MonoBehaviour
{
    public TextMeshProUGUI seedNameText;
    public TextMeshProUGUI levelRequirementText;
    public Image seedImage;

    private PlantData plant;

    // Bu fonksiyon, panelin bilgilerini yapılandırmak için kullanılacak
    public void InitializePanel(PlantData plantData)
    {
        plant = plantData;
        seedNameText.text = plant.plantSpecies.ToString();
        seedImage.sprite = plant.seed.seedSprite;
        levelRequirementText.text = $"Level {plant.seed.requiredLevel} required";
    }
}
