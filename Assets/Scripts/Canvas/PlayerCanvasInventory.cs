using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCanvasInventory : CanvasInventory
{
    [SerializeField] private CanvasInventory shopCanvasInventory;
    
    private MoneyScript playerMoney;

    void Start()
    {
        base.Start();
        playerMoney = inventory.GetComponent<MoneyScript>();
    }

    public void EquipItem()
    {
        if (ItemSelected.Item == null)
            return;

        inventory.GetComponent<PlayerSkin>().EquipItem(ItemSelected.Item);

        ResetEquippedIndicator(ItemSelected.Item);
        ItemSelected.SetEquippedIndicator(true);
    }

    void ResetEquippedIndicator(ItemScriptable itemSelected)
    {
        foreach(GameObject item in itemsCanvas)
        {
            ItemCanvasInformation itemCanvas = item.GetComponent<ItemCanvasInformation>();

            if(itemSelected.TypeItem == itemCanvas.Item.TypeItem)
            {
                itemCanvas.SetEquippedIndicator(false);
            }
        }
    }

    public void SellItem()
    {
        ItemCanvasInformation itemData = ItemSelected;
        if (itemData == null)
            return;

        if(itemData.Item.TypeItem == ItemScriptable.ItemType.Skin)
        {
            if(inventory.NumberOfSkinsOnInventory() <= 1 || itemData.Item.IsEquipped)
            {

                inventoryInformation.ShowInformation("Can't sell item");
                return;
            }
        }
        playerMoney.AddMoney(itemData.Item.ItemPrice);

        shopCanvasInventory.AddItem(itemData.Item);
        RemoveItem();
        UnequipItem(itemData.Item);
    }
    public void UnequipItem()
    {
        UnequipItem(ItemSelected.Item);
    }

    public void UnequipItem(ItemScriptable item)
    {
        if (item == null)
            return;
        if (!item.IsEquipped)
        {
            inventoryInformation.ShowInformation("Item not equipped");
            return;
        }

        if (item.TypeItem == ItemScriptable.ItemType.Skin)
        {
            if (inventory.NumberOfSkinsOnInventory() <= 1 || item.IsEquipped)
            {
                inventoryInformation.ShowInformation("Can't unequip");
                return;
            }
        }
        ItemSelected.SetEquippedIndicator(false);
        inventory.GetComponent<PlayerSkin>().UnequipItem(item);
    }
}
