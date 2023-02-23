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
    
    
    public void SaveLevelData()
    {
        wave = WaveSpawner.currWaveStatic;
        levelName = SceneManager.GetActiveScene().name;
    }

    public void LoadLevelData()
    {
        WaveSpawner.currWaveStatic = wave;
        if (SceneManager.GetActiveScene().name != levelName)
        {
            SceneManager.LoadScene(levelName);
        }



    }

}
