using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayScript : MonoBehaviour
{
    public void ShowHowToPlayPanel(GameObject panel)
    {
        if(panel.activeSelf)
            panel.SetActive(false);
        else
            panel.SetActive(true);
    }
}
