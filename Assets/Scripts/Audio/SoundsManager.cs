using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip[] musicClips;
    

    public void GameOverSound()
    {
        audioSource.PlayOneShot(gameOver);
    }
    
    void Start()
    {
        StartCoroutine(PlayRandom());
    }
    
    
    
    IEnumerator PlayRandom()
    {
        while (true)
        {
            int index = Random.Range(0, musicClips.Length);
            musicSource.clip = musicClips[index];
            musicSource.Play();
            yield return new WaitForSeconds(musicClips[index].length);
            StartCoroutine(PlayRandom());
        }
      



    }
    
    
}
