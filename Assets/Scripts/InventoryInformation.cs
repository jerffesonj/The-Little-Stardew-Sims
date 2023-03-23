using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryInformation : MonoBehaviour
{
    [SerializeField] private GameObject itemInformation;
    [SerializeField] private TMP_Text itemInformationText;

    Coroutine routine = null;
    public void ShowInformation(string text)
    {
        itemInformationText.text = text;
        if (routine != null)
            return;
        routine = StartCoroutine(TurnOffCountdown());
    }

    IEnumerator TurnOffCountdown()
    {
        itemInformation.SetActive(true);
        yield return new WaitForSeconds(1);
        itemInformation.SetActive(false);
        routine = null;
    }

    private void OnDisable()
    {
        routine = null;
        itemInformation.SetActive(false);
    }
}
