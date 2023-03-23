using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperScript : Inventory
{
    [SerializeField] private GameObject shopButton;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        base.Awake();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shopButton.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shopButton.SetActive(false);
            playerMovement.enabled = true;
        }
    }
}
