using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemScriptable> items = new List<ItemScriptable>();

    public List<ItemScriptable> Items { get => items; }

    protected void Awake()
    {
        ResetEquippedItems();
    }

    void ResetEquippedItems()
    {
        foreach (ItemScriptable item in items)
        {
            item.IsEquipped = false;
        }
    }

    public int NumberOfSkinsOnInventory()
    {
        int counter = 0;
        foreach (ItemScriptable item in items)
        {
            if (item.TypeItem == ItemScriptable.ItemType.Skin)
                counter++;
        }

        return counter;
    }
}
