using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMoneyCanvas : MonoBehaviour
{
    public TMP_Text moneyText;
    // Start is called before the first frame update
    void Awake()
    {
        MoneyScript.onChange += ChangeMoneyValue;
    }

    void ChangeMoneyValue(int value)
    {
        moneyText.text = value.ToString();
    }
}
