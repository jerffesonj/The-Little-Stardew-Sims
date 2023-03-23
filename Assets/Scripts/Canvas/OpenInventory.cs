using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    //Only used by the PlayerInventory
    public GameObject equipButton;
    public GameObject sellButton;
   
    public void OpenInventoryByButton()
    {
        equipButton.SetActive(true);
        sellButton.SetActive(false);
        gameObject.SetActive(true);
    }
    public void OpenInventoryByShop()
    {
        equipButton.SetActive(false);
        sellButton.SetActive(true);
        gameObject.SetActive(true);
    }

    public void OpenShopkeeperInventory(GameObject gameObj)
    {
        gameObj.SetActive(true);

        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        playerMovement.StopMovement();
        playerMovement.enabled = false;
    }

    public void CloseShopkeeperInventory(GameObject gameObj)
    {
        gameObj.SetActive(false);
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        playerMovement.enabled = true;
    }
}
