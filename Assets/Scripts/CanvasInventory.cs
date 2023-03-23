using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInventory : MonoBehaviour
{
    public Inventory inventory;
    public List<GameObject> itemsCanvas;
    public GameObject itemCanvasPrefab;
    public RectTransform itemCanvasParent;

    public ItemCanvasInformation itemSelected;
    // Start is called before the first frame update
    protected void Start()
    {
        InitializeInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeInventory()
    {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            GameObject itemCanvasClone = InstantiateItemCanvas();
            itemCanvasClone.GetComponent<ItemCanvasInformation>().SetInformation(inventory.items[i]);
        }
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
            GameObject itemCanvasClone = null;
            itemCanvasClone = itemsCanvas[i];
            itemCanvasClone.GetComponent<ItemCanvasInformation>().ResetInformation();
            itemCanvasClone.SetActive(false);
        }
    }

    GameObject InstantiateItemCanvas()
    {
        GameObject itemCanvasClone  = Instantiate(itemCanvasPrefab, itemCanvasParent);
        itemCanvasClone.GetComponent<ItemCanvasInformation>().inventory = this;
        itemsCanvas.Add(itemCanvasClone);
        return itemCanvasClone;
    }
    public void RemoveItem()
    {
        inventory.items.Remove(itemSelected.item);
        print(itemSelected.item.itemName);
        itemSelected.RemoveHighlight();
        itemSelected = null;
        UpdateInventory();
    }

}
