using UnityEngine;


public class SeedShopManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public PlantFactory plantFactory;
    void Start()
    {
        inventoryManager=GetComponent<InventoryManager>();

    }
    public void BuySeed(PlantSpecies species, int amount)
    {
        // Bitkinin prototipini klonla
        Plant plantPrototype = plantFactory.CreatePlant(species);

        if (plantPrototype != null)
        {
            inventoryManager.AddSeed(plantPrototype.plantData, amount);
            Debug.Log($"{amount} adet {species} tohum satın alındı!");
        }
        else
        {
            Debug.LogError("Tohum bulunamadı!");
        }
    }
    public void BuySeed()
    {
        Debug.Log($" tohumu satın alındı!");
    }
}
