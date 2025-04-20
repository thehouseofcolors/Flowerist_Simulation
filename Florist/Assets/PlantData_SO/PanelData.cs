using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


//this will produce single SO
[CreateAssetMenu(fileName = "PanelData", menuName = "ScriptableObjects/PanelData")]

public class PanelData : ScriptableObject
{
    //these are base prefabs for the inventory and shop items
    //they should be initialized after they instantiated
    public SeedInventoryItem seedInventoryItemPrefab; // Prefab for the seed inventory item
    public GameObject flowerInventoryItemPrefab; // Prefab for the flower inventory item
    public SeedShopItem seedShopItemPrefab; // Prefab for the seed shop item

    public GameObject flowerShopItemPrefab; // Prefab for the flower shop item
    public GameObject sproutItemPrefab; // Prefab for the sprout item
    
    //GameObjects will be changed in the future
}