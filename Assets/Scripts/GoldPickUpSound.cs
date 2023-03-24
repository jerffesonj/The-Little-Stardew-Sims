using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickUpSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float volume;
    
    public void PlayGetGoldSound()
    {
        audioSource.PlayOneShot(audioClip, volume);
    }
}
