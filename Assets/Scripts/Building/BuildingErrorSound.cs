using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingErrorSound : MonoBehaviour
{
   [Header("Audio Variables")]
   [SerializeField] private AudioSource audioSource;
   [SerializeField] private AudioClip errorSound;
   [SerializeField] private AudioClip rareErrorSound;

   [Header("Others")] private int randChance;
   




   public void PlaySound()
   {
       audioSource.PlayOneShot(errorSound);
   }


   



}
