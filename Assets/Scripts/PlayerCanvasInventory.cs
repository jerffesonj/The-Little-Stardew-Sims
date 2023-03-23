using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanvasInventory : CanvasInventory
{
    public CanvasInventory shopCanvasInventory;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            UpdateInventory();
    }
    public void EquipItem()
    {
        inventory.GetComponent<PlayerSkin>().EquipItem(itemSelected.item);
    }
    public void BuyItem()
    {

        ItemCanvasInformation itemInformation = shopCanvasInventory.itemSelected;
        if (itemInformation == null)
            return;

        inventory.items.Add(itemInformation.item);
        UpdateInventory();

        shopCanvasInventory.RemoveItem();

    }

    public void SellItem()
    {
        inventory.items.Remove(itemSelected.item);

        itemSelected.RemoveHighlight();
        itemSelected = null;
        UpdateInventory();
    }

    
}
