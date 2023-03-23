using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasInventory : MonoBehaviour
{
    [SerializeField] protected Inventory inventory;
    
    [SerializeField] private GameObject itemCanvasPrefab;
    [SerializeField] private RectTransform itemCanvasParent;
    [SerializeField] private List<GameObject> itemsCanvas;

    [SerializeField] private ItemCanvasInformation itemSelected;
    protected InventoryInformation inventoryInformation;

    public ItemCanvasInformation ItemSelected { get => itemSelected; set => itemSelected = value; }

    private void OnEnable()
    {
        UpdateInventory();
    }

    protected void Start()
    {
        inventoryInformation = GetComponent<InventoryInformation>();
    }

    public void UpdateInventory()
    {
        ResetInventory();

        for (int i = 0; i < inventory.items.Count; i++)
        {
            GameObject itemCanvasClone = null;
            if (i < itemsCanvas.Count)
            {
                itemCanvasClone = itemsCanvas[i];
                itemCanvasClone.GetComponent<ItemCanvasInformation>().SetInformation(inventory.items[i]);
                itemCanvasClone.SetActive(true);
            }
            else
            {
                itemCanvasClone = InstantiateItemCanvas();
                itemCanvasClone.GetComponent<ItemCanvasInformation>().SetInformation(inventory.items[i]);
            }
        }
    }

    void ResetInventory()
    {
        for (int i = 0; i < itemsCanvas.Count; i++)
        {
            GameObject itemCanvasClone = itemsCanvas[i];
            itemCanvasClone.GetComponent<ItemCanvasInformation>().ResetInformation();
            itemCanvasClone.SetActive(false);
        }
    }

    GameObject InstantiateItemCanvas()
    {
        GameObject itemCanvasClone = Instantiate(itemCanvasPrefab, itemCanvasParent);
        itemCanvasClone.GetComponent<ItemCanvasInformation>().inventory = this;
        itemsCanvas.Add(itemCanvasClone);
        return itemCanvasClone;
    }
   
    public void RemoveItem()
    {
        inventory.items.Remove(ItemSelected.item);
        ItemSelected.RemoveHighlight();
        ItemSelected = null;
        UpdateInventory();
    }
    public void AddItem(ItemScriptable item)
    {
        inventory.items.Add(item);
        UpdateInventory();
    }


    //Called by shopkeeper button
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }
}
