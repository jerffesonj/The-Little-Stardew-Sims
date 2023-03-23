using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInformationTooltip : MonoBehaviour
{
    public GameObject tooltip;
    public void ShowInformationTooltip(bool value)
    {
        tooltip.SetActive(value);
    }
}
