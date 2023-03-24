using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasInventory : MonoBehaviour
{
    [SerializeField] protected Inventory inventory;

    [Header("Audios")]
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip errorSound;
    [SerializeField] protected AudioClip correctSound;

    [Header("Instantiate objects")]
    [SerializeField] private GameObject itemCanvasPrefab;
    [SerializeField] private RectTransform itemCanvasParent;
    [SerializeField] protected List<GameObject> itemsCanvas;

    private ItemCanvasInformation itemSelected;
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

        for (int i = 0; i < inventory.Items.Count; i++)
        {
            GameObject itemCanvasClone = null;
            if (i < itemsCanvas.Count)
            {
                itemCanvasClone = itemsCanvas[i];
                itemCanvasClone.GetComponent<ItemCanvasInformation>().SetInformation(inventory.Items[i]);
                itemCanvasClone.SetActive(true);
            }
            else
            {
                itemCanvasClone = InstantiateItemCanvas();
                itemCanvasClone.GetComponent<ItemCanvasInformation>().SetInformation(inventory.Items[i]);
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
        itemCanvasClone.GetComponent<ItemCanvasInformation>().Inventory = this;
        itemsCanvas.Add(itemCanvasClone);
        return itemCanvasClone;
    }
   
    public void RemoveItem()
    {
        inventory.Items.Remove(ItemSelected.Item);
        ItemSelected.RemoveHighlight();
        ItemSelected = null;
        UpdateInventory();
    }
    public void AddItem(ItemScriptable item)
    {
        inventory.Items.Add(item);
        UpdateInventory();
    }

    protected void PlayCorrectSound()
    {
        audioSource.PlayOneShot(correctSound);
    }
    
    protected void PlayErrorSound()
    {
        audioSource.PlayOneShot(errorSound);
    }
    //Called by shopkeeper button
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }


}
