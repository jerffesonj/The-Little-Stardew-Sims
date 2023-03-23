using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    public List<ItemScriptable> items = new List<ItemScriptable>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
