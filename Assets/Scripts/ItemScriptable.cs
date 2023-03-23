using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Item", order = 1)]
public class ItemScriptable : ScriptableObject
{
    public string itemName;
    public int itemPrice;
    public Sprite itemIcon;
    public ItemType itemType;

    public bool isEquipped;
    public enum ItemType
    {
        Hair,
        Skin,
        Shirt,
        Weapon,
        Shoe,
        Default
    }

}
