using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperScript : Inventory
{
    public GameObject shopButton;

    public PlayerMovement playerMovement;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shopButton.SetActive(true);

            
            print("Welcome");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shopButton.SetActive(false);
            playerMovement.enabled = true;

            print("Goodbye");
        }
    }
}
