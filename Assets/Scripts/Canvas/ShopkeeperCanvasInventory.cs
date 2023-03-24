using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopkeeperCanvasInventory : CanvasInventory
{
    [SerializeField] private CanvasInventory playerCanvasInventory;
    private MoneyScript playerMoney;

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

        if (itemInformation.Item.ItemPrice > playerMoney.Money)
        {
            inventoryInformation.ShowInformation("No cash");
            PlayErrorSound();
            return;
        }

        inventoryInformation.ShowInformation("Item purchased");
        PlayCorrectSound();

        playerMoney.RemoveMoney(itemInformation.Item.ItemPrice);

        playerCanvasInventory.AddItem(itemInformation.Item);

        RemoveItem();
    }
}
