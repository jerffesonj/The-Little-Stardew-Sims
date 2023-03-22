using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInventory : MonoBehaviour
{
    public Inventory inventory;
    public List<GameObject> playerItemsCanvas;
    public GameObject itemCanvasPrefab;
    public RectTransform itemCanvasParent;

    // Start is called before the first frame update
    void Start()
    {
        InitializeInventory();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            UpdateInventory();
    }

    void InitializeInventory()
    {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            GameObject itemCanvasClone = Instantiate(itemCanvasPrefab, itemCanvasParent);
            playerItemsCanvas.Add(itemCanvasClone);
            itemCanvasClone.GetComponent<ItemCanvasInformation>().SetInformation(inventory.items[i]);
        }
    }
    public void UpdateInventory()
    {
        ResetInventory();

        for (int i = 0; i < inventory.items.Count; i++)
        {
            GameObject itemCanvasClone = null;
            if (i < playerItemsCanvas.Count)
            {
                itemCanvasClone = playerItemsCanvas[i];
                itemCanvasClone.GetComponent<ItemCanvasInformation>().SetInformation(inventory.items[i]);
            }
            else
            {
                itemCanvasClone = Instantiate(itemCanvasPrefab, itemCanvasParent);
                playerItemsCanvas.Add(itemCanvasClone);
                itemCanvasClone.GetComponent<ItemCanvasInformation>().SetInformation(inventory.items[i]);
            }
        }
    }
    void ResetInventory()
    {
        for (int i = 0; i < playerItemsCanvas.Count; i++)
        {
            GameObject itemCanvasClone = null;
            itemCanvasClone = playerItemsCanvas[i];
            itemCanvasClone.GetComponent<ItemCanvasInformation>().ResetInformation();
        }
    }
}
