using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UI_SeedShop : MonoBehaviour
{
    #region Variables
    private Canvas shopCanvas; // Canvas referansı
    public Button shopButton;      
    public Button closeButton;
    public Transform contentPanel;
    public PlantManager plantManager;
    
    public int playerLevel = 1;
    #endregion

    #region prefabSettings
    [Header("Seed Panel Prefabs")]
    public GameObject seedPanelPrefab;  // Aktif seed panel prefab
    public GameObject lockPanelPrefab;  // Kilitli seed panel prefab
    #endregion
     
    void Start()
    {

        // Shop objesinin altındaki Canvas'a eriş
        shopCanvas = GetComponentInChildren<Canvas>();

        // İçeriği taşıyan Content Panel'e eriş
        contentPanel = shopCanvas.transform.Find("Scroll View/Viewport/Content");
        plantManager = FindObjectOfType<PlantManager>();

        // Butonları dinleyiciye bağlayalım
        shopButton.onClick.AddListener(OpenShop);
        closeButton.onClick.AddListener(CloseShop);

        // Oyun başında Shop Canvas kapalı olsun
        shopCanvas.gameObject.SetActive(true);

        // Seed'leri oluştur
        CreateSeedUI();
    }

    void OpenShop()=>shopCanvas.gameObject.SetActive(true);
    

    void CloseShop()=>shopCanvas.gameObject.SetActive(false);
    
   

    void CreateSeedUI()
    {
        Dictionary<PlantSpecies, PlantData> plantInventory = plantManager.PlantInventory;
        foreach (KeyValuePair<PlantSpecies, PlantData> plantEntry in plantInventory)
        {
            PlantData plant = plantEntry.Value; // Değer (PlantData) erişimi
            PlantSpecies species = plantEntry.Key; // Anahtar (PlantSpecies) erişimi

            // Bitkiyi UI'ye ekle
            if (plant.seed.requiredLevel <= playerLevel)  // Eğer oyuncu yeterli seviyeye sahipse
            {
                GameObject seedPanel = Instantiate(seedPanelPrefab, contentPanel);
                // Normal panel olduğu için, NormalSeedPanel scriptine erişip InitializePanel çağırıyoruz
                NormalSeedPanel panelScript = seedPanel.GetComponent<NormalSeedPanel>();
                if (panelScript != null)
                {
                    panelScript.InitializePanel(plant);  // Bitkiyi başlatmak için InitializePanel'i çağırıyoruz
                }
            }
            else
            {
                GameObject lockPanel = Instantiate(lockPanelPrefab, contentPanel);
                // Kilitli panel olduğu için, LockedSeedPanel scriptine erişip InitializePanel çağırıyoruz
                LockedSeedPanel panelScript = lockPanel.GetComponent<LockedSeedPanel>();
                if (panelScript != null)
                {
                    panelScript.InitializePanel(plant);  // Kilitli panelde de InitializePanel'i çağırıyoruz
                }
            }
        }
    }
    
    

}
