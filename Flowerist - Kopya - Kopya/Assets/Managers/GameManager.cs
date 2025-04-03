using UnityEngine;

public class GameManager : Singleton<GameManager> {

    public DataManager gameData;

    private void Start()
    {
        gameData.LoadAllData(); // 📌 Oyun açıldığında veriyi yükle
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