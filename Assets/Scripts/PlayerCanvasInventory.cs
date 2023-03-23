using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class PlayerCanvasInventory : CanvasInventory
{
    public CanvasInventory shopCanvasInventory;
    public MoneyScript playerMoney;
    
    void Start()
    {
        base.Start();
        playerMoney = inventory.GetComponent<MoneyScript>();
    }

    public void EquipItem()
    {
        if (itemSelected.item == null)
            return;
        itemSelected.SetEquippedIndicator(true);
        inventory.GetComponent<PlayerSkin>().EquipItem(itemSelected.item);
    }
    public void BuyItem()
    {

        ItemCanvasInformation itemInformation = shopCanvasInventory.itemSelected;
        if (itemInformation == null)
            return;

        if (itemInformation.item.itemPrice > playerMoney.Money)
        {
            Debug.Log("No cash");
            return;
        }
        playerMoney.RemoveMoney(itemInformation.item.itemPrice);

        AddItem(itemInformation.item);

        shopCanvasInventory.RemoveItem();

    }

    public void SellItem()
    {
        ItemCanvasInformation itemInformation = itemSelected;
        if (itemInformation == null)
            return;


        if(itemInformation.item.itemType == ItemScriptable.ItemType.Skin)
        {
            if(inventory.NumberOfSkinsOnInventory() <= 1 || itemInformation.item.isEquipped)
            {
                Debug.Log("Can't sell");
                return;
            }
        }
        playerMoney.AddMoney(itemInformation.item.itemPrice);



        shopCanvasInventory.AddItem(itemInformation.item);
        RemoveItem();
        UnequipItem(itemInformation.item);
    }
    public void UnequipItem()
    {
        UnequipItem(itemSelected.item);
    }

    public void UnequipItem(ItemScriptable item)
    {
        if (item == null)
            return;
        if (item.itemType == ItemScriptable.ItemType.Skin)
        {
            if (inventory.NumberOfSkinsOnInventory() <= 1 || item.isEquipped)
            {
                Debug.Log("Can't Unequip");
                return;
            }
        }
        itemSelected.SetEquippedIndicator(false);
        inventory.GetComponent<PlayerSkin>().UnequipItem(item);
    }


}
