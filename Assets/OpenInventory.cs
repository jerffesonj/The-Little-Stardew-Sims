using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject equipButton;
    public GameObject sellButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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

}
