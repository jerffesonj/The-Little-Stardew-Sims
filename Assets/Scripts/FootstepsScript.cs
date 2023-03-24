using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip footstep;
    [SerializeField] private float volume;
    public void PlayFootstep()
    {
        audioSource.PlayOneShot(footstep, volume);
    }
}
