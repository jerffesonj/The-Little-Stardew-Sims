using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Item", order = 1)]
public class ItemScriptable : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private int itemPrice;
    [SerializeField] private Sprite itemIcon;
    [SerializeField] private ItemType typeItem;

    [SerializeField] private bool isEquipped;

    public string ItemName { get => itemName; }
    public int ItemPrice { get => itemPrice; }
    public Sprite ItemIcon { get => itemIcon; }
    public ItemType TypeItem { get => typeItem; }
    public bool IsEquipped { get => isEquipped; set => isEquipped = value; }

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
