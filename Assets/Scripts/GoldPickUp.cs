using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickUp : MonoBehaviour
{
    [SerializeField] private int coins;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<MoneyScript>().AddMoney(coins);
            Destroy(this.gameObject);
        }
    }
}
