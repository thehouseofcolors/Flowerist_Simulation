using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class SeedShopManager : Singleton<SeedShopManager>
{
    [SerializeField] AllPlants allPlantsList;//these are the data of the plants
    [SerializeField] PanelData panelDataList;//these are the prefabs
    //prefabs should be instantiated and then initialized with data
    private SeedShopItem seedShopItemPrefab;
    private void Start()
    {
        seedShopItemPrefab = panelDataList.seedShopItemPrefab;
        for (int i = 0; i < allPlantsList.allPlants.Count; i++)
        {
            GenerateSeedShopItems(seedShopItemPrefab, allPlantsList.allPlants[i]);
        }
    }

    void GenerateSeedShopItems(SeedShopItem seedShopItemPrefab, PlantData plantData)
    {
        
        SeedShopItem seedShopItem = Instantiate(seedShopItemPrefab, transform);
        if(plantData.seed.requiredLevel >= PlayerPrefs.GetInt(LevelManager.LevelKey, 0))
        {
            seedShopItem.Setup(plantData.seed.seedPackSprite, plantData.seed.seedPackPrice);
        }
        else
        {
            seedShopItem.SetupLocked(plantData.seed.requiredLevel);
        }
    }
    
}
