using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class PlayerCanvasInventory : CanvasInventory
{
    public CanvasInventory shopCanvasInventory;
    public MoneyScript playerMoney;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        playerMoney = inventory.GetComponent<MoneyScript>();
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

        if (itemInformation.item.itemPrice > playerMoney.money)
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
    public void UnequipItem(ItemScriptable item)
    {
        inventory.GetComponent<PlayerSkin>().UnequipItem(item);
    }


}
