using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("Main UI References")]
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private TMP_Text _xpText;

    void Start()
    {
        UpdateCoreUI();   
    }
    private void OnEnable()
    {
        EventManager.OnLevelUpdate += UpdateCoreUI;
        EventManager.OnMoneyChanged += UpdateMoneyUI;
    }

    private void OnDisable()
    {
        EventManager.OnLevelUpdate -= UpdateCoreUI;
        EventManager.OnMoneyChanged -= UpdateMoneyUI;
    }

    public void UpdateCoreUI()
    {
        if (_levelText != null) 
            _levelText.text = $"Level: {DataManager.Level}";
        
        UpdateMoneyUI();
        UpdateXPUI();
    }

    private void UpdateMoneyUI()
    {
        if (_moneyText != null)
            _moneyText.text = $"Coins: {DataManager.Money}";
    }

    private void UpdateXPUI()
    {
        if (_xpText != null)
            _xpText.text = $"XP: {DataManager.XP}";
    }

    
}