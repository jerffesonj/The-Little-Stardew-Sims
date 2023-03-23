using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCanvasInventory : CanvasInventory
{
    public CanvasInventory shopCanvasInventory;
    
    private MoneyScript playerMoney;


    void Start()
    {
        base.Start();
        playerMoney = inventory.GetComponent<MoneyScript>();
    }

    public void EquipItem()
    {
        if (ItemSelected.item == null)
            return;
        ItemSelected.SetEquippedIndicator(true);
        inventory.GetComponent<PlayerSkin>().EquipItem(ItemSelected.item);
    }

    public void SellItem()
    {
        ItemCanvasInformation itemData = ItemSelected;
        if (itemData == null)
            return;

        if(itemData.item.itemType == ItemScriptable.ItemType.Skin)
        {
            if(inventory.NumberOfSkinsOnInventory() <= 1 || itemData.item.isEquipped)
            {

                inventoryInformation.ShowInformation("Can't sell item");
                return;
            }
        }
        playerMoney.AddMoney(itemData.item.itemPrice);

        shopCanvasInventory.AddItem(itemData.item);
        RemoveItem();
        UnequipItem(itemData.item);
    }
    public void UnequipItem()
    {
        UnequipItem(ItemSelected.item);
    }

    public void UnequipItem(ItemScriptable item)
    {
        if (item == null)
            return;
        if (item.itemType == ItemScriptable.ItemType.Skin)
        {
            if (inventory.NumberOfSkinsOnInventory() <= 1 || item.isEquipped)
            {
                inventoryInformation.ShowInformation("Can't unequip");
                return;
            }
        }
        ItemSelected.SetEquippedIndicator(false);
        inventory.GetComponent<PlayerSkin>().UnequipItem(item);
    }
}
