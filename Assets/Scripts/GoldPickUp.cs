using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickUp : MonoBehaviour
{
    [SerializeField] private int coins;
    private GoldPickUpSound sound;

    private void Start()
    {
        sound = GetComponentInParent<GoldPickUpSound>();    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<MoneyScript>().AddMoney(coins);
            sound.PlayGetGoldSound();
            Destroy(this.gameObject);
        }
    }
}
