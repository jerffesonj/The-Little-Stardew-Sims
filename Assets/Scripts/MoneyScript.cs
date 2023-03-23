using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    [SerializeField] int money;

    public int Money { get => money; }

    public delegate void OnMoneyChange(int money);
    public static event OnMoneyChange onChange;
    // Start is called before the first frame update
    void Start()
    {
        onChange?.Invoke(money);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Add Money")]
    public void AddMoney()
    {
        AddMoney(100);
    }

    public void AddMoney(int value)
    {
        money += value;
        onChange?.Invoke(money);
    }
    
    [ContextMenu("Remove Money")]

    public void RemoveMoney()
    {
        RemoveMoney(100);
    }

    public void RemoveMoney(int value)
    {
        money -= value;
        onChange?.Invoke(money);

    }
}
