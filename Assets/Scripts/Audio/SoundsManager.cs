using System;
using System.Collections;
using System.Collections.Generic;
using FG_EnemyAI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip[] musicClips;
    [SerializeField] private AudioClip bossMusic;

    [SerializeField] private WaveSpawner _wave;
    

    public void GameOverSound()
    {
        audioSource.PlayOneShot(gameOver);
    }
    
    void Start()
    {
        StartCoroutine(PlayRandom());
    }

    private void FixedUpdate()
    {
        if (_wave.currWave == 10 && musicSource.clip != bossMusic && SceneManager.GetActiveScene().name == "ForestMap")
        {
            musicSource.clip = bossMusic;
            musicSource.Play();
        }
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
