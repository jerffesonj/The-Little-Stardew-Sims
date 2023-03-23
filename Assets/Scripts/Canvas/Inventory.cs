using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    public List<ItemScriptable> items = new List<ItemScriptable>();
    
    protected void Awake()
    {
        ResetEquippedItems();
    }

    void ResetEquippedItems()
    {
        foreach (ItemScriptable item in items)
        {
            item.isEquipped = false;
        }
    }

    public int NumberOfSkinsOnInventory()
    {
        int counter = 0;
        foreach (ItemScriptable item in items)
        {
            if (item.itemType == ItemScriptable.ItemType.Skin)
                counter++;
        }

        return counter;
    }
}
