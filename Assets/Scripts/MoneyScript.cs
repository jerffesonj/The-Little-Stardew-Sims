using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    [SerializeField] int money;

    public int Money { get => money; }

    public delegate void OnMoneyChange(int money);
    public static event OnMoneyChange onChange;
    
    void Start()
    {
        onChange?.Invoke(money);
    }

    #region Test Methods
    [ContextMenu("Add Money")]
    public void AddMoney()
    {
        AddMoney(100);
    }
    [ContextMenu("Remove Money")]

    public void RemoveMoney()
    {
        RemoveMoney(100);
    }
    #endregion

    public void AddMoney(int value)
    {
        money += value;
        onChange?.Invoke(money);
    }
    
    public void RemoveMoney(int value)
    {
        money -= value;
        onChange?.Invoke(money);

    }
}
