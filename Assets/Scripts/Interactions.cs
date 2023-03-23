using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [SerializeField] private InteractionScriptable interactionScriptable;
    [SerializeField] private GameObject canvas;
    [SerializeField] private TMP_Text phraseText;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            phraseText.text = interactionScriptable.phrase;
            canvas.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canvas.SetActive(false);
        }
    }
}
