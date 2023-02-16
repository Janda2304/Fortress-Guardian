
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Header("Enemies")]
    [SerializeField] private GameObject goblin;
    [SerializeField] private GameObject bear;
    [SerializeField] private GameObject cannon;
    [SerializeField] private GameObject goblinWithCannon;
    [SerializeField] private GameObject goblinOnBear;
    [Header("Sounds")]
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip errorClip;
    [Header("Wave Settings")]
    [SerializeField] private float timeBetweenSpawns = 3f;
    [SerializeField] private int waveCount;
    [Header("UI")]
    [SerializeField] private TMP_Text errorText;
    [SerializeField] private TMP_Text waveText;
    
    #region Private and Hidden vars
    private float timeBetweenWaves = 5f;
    [HideInInspector] public bool isWaveActive = false;
    private bool levelCompleted = false;
    private int wave = 0;
    private GameObject[] enemies;
    #endregion

    private void Start()
    {
        waveText.text = $"{wave}/{waveCount}";
        errorText.gameObject.SetActive(false);
        string difficulty = PlayerPrefs.GetString("difficulty");
        switch (difficulty)
        {
            case "Novice":
                timeBetweenWaves = 75f;
                break;
            case "Journeyman":
                timeBetweenWaves = 45f;
                break;
            case "Master":
                timeBetweenWaves = 15f;
                break;
        }
        
    
    }


    void Update()
    {
       
        enemies = GameObject.FindGameObjectsWithTag("Enemy");



        if (wave == waveCount)
        {
            isWaveActive = false;
            levelCompleted = true;
        }
        if (Input.GetKeyDown(KeyCode.L) && !isWaveActive && !levelCompleted)
        {
            wave++;
            waveText.text = $"{wave}/{waveCount}";
            isWaveActive = true;
            Wave(wave);
        }
        else if (Input.GetKeyDown(KeyCode.L) && isWaveActive || levelCompleted)
        {
            StartCoroutine(ErrorPopup());
        }
           


    }


    void Wave(int wave)
    {
        switch (wave)
        {
            case 1:
                StartCoroutine(SpawnGoblin(5));
                break;
            case 2:
                StartCoroutine(SpawnGoblin(3));
                StartCoroutine(SpawnBear(1));
                break;
            case 3:
                //wave 3
                break;
            case 4:
                //wave 4
                break;
            case 5:
               
                break;
        }
            
        
    }

    IEnumerator SpawnGoblin(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);
            Instantiate(goblin, goblin.GetComponent<EnemyAI>().spawnpoint, Quaternion.identity);

        }
    }
    
    IEnumerator SpawnBear(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);
            Instantiate(bear, bear.GetComponent<EnemyAI>().spawnpoint, Quaternion.identity);
          
        }
    }
    
    IEnumerator ErrorPopup()
    {
        errorText.text = "Can't start a new wave while there is a wave already active";
        errorText.gameObject.SetActive(true);
        source.PlayOneShot(errorClip);
        yield return new WaitForSeconds(0.75f);
        errorText.gameObject.SetActive(false);
        
    }


}
