using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMoneyCanvas : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;
    void Awake()
    {
        MoneyScript.onChange += ChangeMoneyValue;
    }

    void ChangeMoneyValue(int value)
    {
        moneyText.text = value.ToString();
    }
}
