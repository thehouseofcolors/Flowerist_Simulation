using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public static string LevelKey = "CurrentLevel"; // PlayerPrefs anahtar ismi

    // Level kaydetme
    public void SaveLevel(int level)
    {
        PlayerPrefs.SetInt(LevelKey, level); // Level'i kaydet
        PlayerPrefs.Save(); // Değişiklikleri kaydet
    }

    // Level yükleme
    public int LoadLevel()
    {
        return PlayerPrefs.GetInt(LevelKey, 1); // Varsayılan olarak level 1 olsun
    }
}
