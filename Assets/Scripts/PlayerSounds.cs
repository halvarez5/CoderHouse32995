using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource audioSrc;
    [SerializeField] private AudioClip sfx_Hit;
    [SerializeField] private AudioClip sfx_Lose;

    public void HitSound()
    {
        audioSrc.clip = sfx_Hit;
        audioSrc.Play();
    }

    public void LoseSound()
    {
        audioSrc.clip = sfx_Lose;
        audioSrc.Play();
    }

}
