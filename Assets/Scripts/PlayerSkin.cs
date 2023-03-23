using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [Header("Player Sprite Renderers")]
    public SpriteRenderer hairItemRenderer;
    public SpriteRenderer skinItemRenderer;
    public SpriteRenderer shirtItemRenderer;
    public SpriteRenderer weaponItemRenderer;
    public SpriteRenderer shoeItemRenderer;

    [Header("Player Item References")]
    public ItemScriptable hairItemScriptable;
    public ItemScriptable skinItemScriptable;
    public ItemScriptable shirtItemScriptable;
    public ItemScriptable weaponItemScriptable;
    public ItemScriptable shoeItemScriptable;

    void Start()
    {
        UpdateItems();
    }

    void Update()
    {
        
    }
    public void UpdateItems()
    {
        hairItemRenderer.sprite = hairItemScriptable.itemIcon;
        skinItemRenderer.sprite = skinItemScriptable.itemIcon;
        shirtItemRenderer.sprite = shirtItemScriptable.itemIcon;
        weaponItemRenderer.sprite = weaponItemScriptable.itemIcon;
        shoeItemRenderer.sprite = shoeItemScriptable.itemIcon;
    }

    public void EquipItem(ItemScriptable item)
    {
        switch (item.itemType)
        {
            case ItemScriptable.ItemType.Hair:
                hairItemScriptable = item;
                break;
            case ItemScriptable.ItemType.Shirt:
                shirtItemScriptable = item;
                break;
            case ItemScriptable.ItemType.Skin:
                skinItemScriptable = item;
                break;
            case ItemScriptable.ItemType.Shoe:
                shoeItemScriptable = item;
                break;
            case ItemScriptable.ItemType.Weapon:
                weaponItemScriptable = item;
                break;
        }

        UpdateItems();
    }
}
