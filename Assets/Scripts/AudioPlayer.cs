using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip selectSound, singleshotSound, doubleshotSound, healSound, misfireSound, reloadSound;

    public void SelectAudio()
    {
        src.clip = selectSound;
        src.Play();
    }

    public void SingleshotAudio()
    {
        src.clip = singleshotSound;
        src.Play();
    }

    public void DoubleshotAudio()
    {
        src.clip = doubleshotSound;
        src.Play();
    }

    public void HealAudio()
    {
        src.clip = healSound;
        src.Play();
    }

    public void MisfireAudio()
    {
        src.clip = misfireSound;
        src.Play();
    }
    
    public void ReloadAudio()
    {
        src.clip = reloadSound;
        src.Play();
    }
}