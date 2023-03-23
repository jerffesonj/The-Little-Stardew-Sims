using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCanvasInformation : MonoBehaviour
{
    public TMP_Text itemNameText;
    public Image itemIconImage;
    public TMP_Text itemPriceText;
    public CanvasInventory inventory;
    public ItemScriptable item;
    public GameObject selectionHighlight;
    public GameObject equippedIndicator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInformation(ItemScriptable item)
    {
        itemNameText.text = item.itemName;
        itemIconImage.sprite = item.itemIcon;
        itemPriceText.text = item.itemPrice.ToString();
        this.item = item;
        if (item.isEquipped)
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
        if(inventory.itemSelected != null)
            inventory.itemSelected.RemoveHighlight();
        inventory.itemSelected = this;
        selectionHighlight.SetActive(true);
    }

    public void RemoveHighlight()
    {
        selectionHighlight.SetActive(false);
    }
}
