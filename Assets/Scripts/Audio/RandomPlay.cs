using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlay : MonoBehaviour
{
    
    public AudioClip[] clips;
    [SerializeField] private AudioSource audioSource;
    private int index;
    
    void Start()
    {
        StartCoroutine(PlayRandom());
    }


    private IEnumerator PlayRandom()
    {
        index = Random.Range(0, clips.Length);
        audioSource.clip = clips[index];
        audioSource.Play();
        yield return new WaitForSeconds(clips[index].length);
        StartCoroutine(PlayRandom());
    }

}
   