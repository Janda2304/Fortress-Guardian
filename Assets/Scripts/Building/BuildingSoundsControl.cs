using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSoundsControl : MonoBehaviour
{
   [SerializeField] private AudioSource audioSource;
   
   [Header("Audio Clips")]
   [SerializeField] private AudioClip buildingSound;
   [SerializeField] private AudioClip errorSound;
   [SerializeField] private AudioClip rareErrorSound;
   private float rareErrorChance = 0.1f;
   
   
   
   public void PlayBuildingSound()
   {
      audioSource.PlayOneShot(buildingSound);
   }
   
   public void PlayErrorSound()
   {
      if (rareErrorChance >  Random.Range(0f, 100f))
      {
         audioSource.PlayOneShot(rareErrorSound);
      }
      else
      {
         audioSource.PlayOneShot(errorSound);
      }

    
     
   }
   
   

}
