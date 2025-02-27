using UnityEngine;
using UnityEngine.UI;

public class InventoryPanelManager : MonoBehaviour
{
    public GameObject seedPanel;   // Seed panel objesi
    public GameObject flowerPanel; // Flower panel objesi

    public Button seedButton;      // Seed panel butonu
    public Button flowerButton;    // Flower panel butonu

    void Start()
    {
        // Başlangıçta Seed paneli aktif olsun, diğerini gizle
        ShowSeedPanel();

        // Butonlara listener ekleyelim
        seedButton.onClick.AddListener(ShowSeedPanel);
        flowerButton.onClick.AddListener(ShowFlowerPanel);
    }

    void ShowSeedPanel()
    {
        // Seed panelini göster, flower panelini gizle
        seedPanel.SetActive(true);
        flowerPanel.SetActive(false);
    }

    void ShowFlowerPanel()
    {
        // Flower panelini göster, seed panelini gizle
        flowerPanel.SetActive(true);
        seedPanel.SetActive(false);
    }
}
