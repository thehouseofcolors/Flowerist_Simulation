using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    public DataManager gameData;
    [SerializeField] TMP_Text levelText;
    [SerializeField] TMP_Text moneyText;


    private void Start()
    {
        PlayerPrefs.DeleteAll();
        gameData.LoadAllData(); // 📌 Oyun açıldığında veriyi yükle
        UpdateUI();
    }
    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        EventManager.OnLevelUpdate +=UpdateUI;
    }
    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        EventManager.OnLevelUpdate -=UpdateUI;
        
    }

    public void UpdateUI()
    {
        levelText.text =$"Level: {DataManager.Level}";
        moneyText.text = $"Coins: {DataManager.Money}";
    }
    public void GoToSeedShop() {
        SceneLoader.Instance.LoadScene("SeedShop");
    }

    public void GoToGarden() {
        SceneLoader.Instance.LoadScene("Garden");
    }

    public void GoToFlowerShop() {
        SceneLoader.Instance.LoadScene("FlowerShop");
    }

    
}