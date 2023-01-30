using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider masterVolume;
    public Slider musicVolume;
    public Slider soundVolume;
    [SerializeField] private AudioMixer mixer;

    private void Start()
    {
        LoadVolume();
    }

    public void ChangeMasterVolume()
    {
        mixer.SetFloat("Master", masterVolume.value);
        PlayerPrefs.SetFloat("Master", masterVolume.value);
        
    }
    
    public void ChangeMusicVolume()
    {
        mixer.SetFloat("Music", musicVolume.value);
        PlayerPrefs.SetFloat("Music", musicVolume.value);
    }
    
    public void ChangeSoundVolume()
    {
        mixer.SetFloat("Sound", soundVolume.value);
        PlayerPrefs.SetFloat("Sound", soundVolume.value);
    }
    
    private void LoadVolume()
    {
        if (!PlayerPrefs.HasKey("Master") || !PlayerPrefs.HasKey("Music") || !PlayerPrefs.HasKey("Sound"))
        {
            mixer.SetFloat("Master", 0);
            mixer.SetFloat("Music", 0);
            mixer.SetFloat("Sound", 0);
            masterVolume.value = 0;
            musicVolume.value = 0;
            soundVolume.value = 0;
        }
        masterVolume.value = PlayerPrefs.GetFloat("Master");
        musicVolume.value = PlayerPrefs.GetFloat("Music");
        soundVolume.value = PlayerPrefs.GetFloat("Sound");
        mixer.SetFloat("Master", masterVolume.value);
        mixer.SetFloat("Music", musicVolume.value);
        mixer.SetFloat("Sound", soundVolume.value);
    }
    
}
