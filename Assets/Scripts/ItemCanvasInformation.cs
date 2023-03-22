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
    }
    public void ResetInformation()
    {
        itemNameText.text = "";
        itemIconImage.sprite = null;
        itemPriceText.text = "";
    }
}
