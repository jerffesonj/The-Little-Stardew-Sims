using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopkeeperCanvasInventory : CanvasInventory
{
    MoneyScript playerMoney;
    public CanvasInventory playerCanvasInventory;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        playerMoney = FindObjectOfType<MoneyScript>();
    }

    public void BuyItem()
    {
        ItemCanvasInformation itemInformation = ItemSelected;
        if (itemInformation == null)
            return;

        if (itemInformation.item.itemPrice > playerMoney.Money)
        {
            inventoryInformation.ShowInformation("No cash");
            return;
        }

        inventoryInformation.ShowInformation("Item purchased");

        playerMoney.RemoveMoney(itemInformation.item.itemPrice);

        playerCanvasInventory.AddItem(itemInformation.item);

        RemoveItem();
    }
}
