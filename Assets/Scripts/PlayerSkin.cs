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
        skinItemScriptable.IsEquipped = true;
    }

    public void UpdateItems()
    {
        if (hairItemScriptable)
            hairItemRenderer.sprite = hairItemScriptable.ItemIcon;
        else
            hairItemRenderer.sprite = null;

        if (skinItemScriptable)
            skinItemRenderer.sprite = skinItemScriptable.ItemIcon;
        else
            skinItemRenderer.sprite = null;

        if (shirtItemScriptable)
            shirtItemRenderer.sprite = shirtItemScriptable.ItemIcon;
        else
            shirtItemRenderer.sprite = null;

        if (weaponItemScriptable)
            weaponItemRenderer.sprite = weaponItemScriptable.ItemIcon;
        else
            weaponItemRenderer.sprite = null;

        if (shoeItemScriptable)
            shoeItemRenderer.sprite = shoeItemScriptable.ItemIcon;
        else
            shoeItemRenderer.sprite = null;

    }

    public void EquipItem(ItemScriptable item)
    {
        switch (item.TypeItem)
        {
            case ItemScriptable.ItemType.Hair:
                UnequipItem(hairItemScriptable);
                hairItemScriptable = item;
                break;
            case ItemScriptable.ItemType.Shirt:
                UnequipItem(shirtItemScriptable);
                shirtItemScriptable = item;
                break;
            case ItemScriptable.ItemType.Skin:
                UnequipItem(skinItemScriptable);
                skinItemScriptable = item;
                break;
            case ItemScriptable.ItemType.Shoe:
                UnequipItem(shoeItemScriptable);
                shoeItemScriptable = item;
                break;
            case ItemScriptable.ItemType.Weapon:
                UnequipItem(weaponItemScriptable);
                weaponItemScriptable = item;
                break;
        }
        item.IsEquipped = true;
        UpdateItems();
    }

    public void UnequipItem(ItemScriptable item)
    {
        if (item == null) return;
        switch (item.TypeItem)
        {
            case ItemScriptable.ItemType.Hair:
                hairItemScriptable = null;
                break;
            case ItemScriptable.ItemType.Shirt:
                shirtItemScriptable = null;
                break;
            case ItemScriptable.ItemType.Skin:
                skinItemScriptable = null;
                break;
            case ItemScriptable.ItemType.Shoe:
                shoeItemScriptable = null;
                break;
            case ItemScriptable.ItemType.Weapon:
                weaponItemScriptable = null;
                break;
        }
        item.IsEquipped = false;

        UpdateItems();
    }
}
