using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource buttonSound;
    public AudioClip mouseOver;
    public AudioClip mouseClick;
    
    
    public void MouseOverSound()
    {
        buttonSound.PlayOneShot(mouseOver);
    }

    public void MouseClickSound()
    {
        buttonSound.PlayOneShot(mouseClick);
    }
}
