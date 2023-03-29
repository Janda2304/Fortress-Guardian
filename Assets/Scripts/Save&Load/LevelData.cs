using System;
using System.Collections;
using System.Collections.Generic;
using FG_EnemyAI;
using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(fileName = "New Level Data", menuName = "Level Data")]
public class LevelData : ScriptableObject
{
    public int wave;
    public string levelName;
    WaveSpawner _waveSpawner;

    public void Awake()
    {
        _waveSpawner = FindObjectOfType<WaveSpawner>();
    }

    public void SaveLevelData()
    {
        wave = _waveSpawner.currWave;
        levelName = SceneManager.GetActiveScene().name;
    }

    public void LoadLevelData()
    {
        _waveSpawner.currWave = wave;
        if (SceneManager.GetActiveScene().name != levelName) SceneManager.LoadScene(levelName);
    }

}
