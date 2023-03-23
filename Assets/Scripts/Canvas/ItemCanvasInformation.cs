using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCanvasInformation : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text itemPriceText;

    [Header("Item Icon")]
    [SerializeField] private Image itemIconImage;

    [Header("GameObjects")]
    [SerializeField] private GameObject selectionHighlight;
    [SerializeField] private GameObject equippedIndicator;
    
    private CanvasInventory inventory;
    private ItemScriptable item;

    public ItemScriptable Item { get => item; }
    public CanvasInventory Inventory { get => inventory; set => inventory = value; }

    public void SetInformation(ItemScriptable item)
    {
        this.item = item;
        itemNameText.text = item.ItemName;
        itemIconImage.sprite = item.ItemIcon;
        itemPriceText.text = item.ItemPrice.ToString();
        if (item.IsEquipped)
            SetEquippedIndicator(true);
    }

    public void SetEquippedIndicator(bool value)
    {
        equippedIndicator.SetActive(value);
    }

    public void ResetInformation()
    {
        itemNameText.text = "";
        itemIconImage.sprite = null;
        itemPriceText.text = "";
        SetEquippedIndicator(false);
    }

    public void SetCurrentInventoryCanvasObject()
    {
        if(inventory.ItemSelected != null)
            inventory.ItemSelected.RemoveHighlight();

        inventory.ItemSelected = this;
        selectionHighlight.SetActive(true);
    }

    public void RemoveHighlight()
    {
        selectionHighlight.SetActive(false);
    }
}
