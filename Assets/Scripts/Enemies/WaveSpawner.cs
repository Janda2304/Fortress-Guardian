using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


namespace FG_EnemyAI
{


    public class WaveSpawner : MonoBehaviour
    {
        [Header("UI")] 
        [SerializeField] private TMP_Text waveTimerText;
        [SerializeField] private TMP_Text waveNumberText;
        [SerializeField] private TMP_Text waveActiveErrorText;
        [SerializeField] private TMP_Text startWaveText;

        [Header("Wave Settings")] 
        public int currWave;
        public int waveDuration;
        private float waveTimer;
        private float spawnInterval;
        private float spawnTimer;

        [SerializeField] [Tooltip("How many waves this map should have")]
        private int waveCount;

        [SerializeField] [Tooltip("How much value will add up for every wave")]
        private int waveValueIncrease;

        /*[HideInInspector]*/
        public bool waveActive;
        private int waveValue;

        [Header("Enemy Settings")] public List<Enemy> enemies = new List<Enemy>();
        private List<Enemy> spawnableEnemies = new List<Enemy>();
        public List<GameObject> enemiesToSpawn = new List<GameObject>();
        public Transform[] spawnLocation;
        public int spawnIndex;
        public List<GameObject> spawnedEnemies = new List<GameObject>();
        [Header("Win")]
        public GameObject winScreen;
        [Header("Other Scripts")] [SerializeField]
        private WinScreen _win;
        

        private void Start()
        {
            waveActiveErrorText.text = "Wave is already active!";
            waveActiveErrorText.gameObject.SetActive(false);
        }

        private void Update()
        {
            
            #region Wave Timer
            if (currWave <= waveCount)
            {
                waveTimerText.text = $"{decimal.Round(Convert.ToDecimal(waveTimer), 1)}s";
            }
            #endregion
            
            #region Start Wave
            //starts wave on a key press
            waveNumberText.text = $"{currWave}/{waveCount}";
            if (Input.GetKeyDown(KeyCode.L) && !waveActive && currWave < waveCount)
            {
                StartNewWave();
            }
            else if (Input.GetKeyDown(KeyCode.L) && waveActive)
            {
                StartCoroutine(ErrorPopup());
            }
            #endregion
            
           
            //ends wave if all enemies are killed
            if (spawnedEnemies.Count == 0 && waveActive && waveTimer < waveDuration - spawnInterval) EndWave();
            //executes when all waves are done and no enemies are left to spawn
            if (currWave >= waveCount && spawnedEnemies.Count == 0 && !waveActive) Win();

        }

        void FixedUpdate()
        {
            if (waveActive)
            {
                waveTimer -= Time.fixedDeltaTime;
            }

            if (spawnTimer <= 0)
            {
                if (enemiesToSpawn.Count > 0)
                {
                    GameObject enemy = Instantiate(enemiesToSpawn[0], spawnLocation[spawnIndex].position, Quaternion.identity);
                    enemiesToSpawn.Remove(enemy);
                    spawnedEnemies.Add(enemy);
                    spawnTimer = spawnInterval;

                    if (spawnIndex + 1 <= spawnLocation.Length - 1)
                    {
                        spawnIndex++;
                    }
                    else
                    {
                        spawnIndex = 0;
                    }
                }
            }

            else
            {
                spawnTimer -= Time.fixedDeltaTime;
            }
            //starts a new wave if the current wave timer runs out and there are still spawned enemies left 
            if (waveTimer <= 0 && waveActive)
            {
               StartNewWave();
            }
            //ends the wave if there are no enemies left 
            if (spawnedEnemies.Count == 0 && waveActive && waveTimer < waveDuration - spawnInterval)
            {
                EndWave();
            }

        }

        public void GenerateWave()
        {
            waveValue = currWave * waveValueIncrease;
            GenerateEnemies();

            spawnInterval = currWave / 2f;
            if (currWave == 10 && SceneManager.GetActiveScene().name == "ForestMap" )
            {
                waveTimer = 9999999999;
                waveTimerText.text = "Infinite";
            }
            else
            {
                waveTimer = waveDuration;
            }
           
        }

        public void GenerateEnemies()
        {
            List<GameObject> generatedEnemies = new List<GameObject>();
            if (currWave == 10 && SceneManager.GetActiveScene().name == "ForestMap")
            {
                generatedEnemies.Add(enemies[3].enemyPrefab);
            }
            else
            {
                while (waveValue > 0 || generatedEnemies.Count < 50)
                {
                    int randEnemyId = Random.Range(0, spawnableEnemies.Count);
                    int randEnemyCost = spawnableEnemies[randEnemyId].cost;
              
                    if (waveValue - randEnemyCost >= 0)
                    {
                        generatedEnemies.Add(spawnableEnemies[randEnemyId].enemyPrefab);
                        waveValue -= randEnemyCost;
                    }
                    else if (waveValue <= 0)
                    {
                        break;
                    }
                }

            }
            
            enemiesToSpawn.Clear();
            enemiesToSpawn = generatedEnemies;
        }

        private IEnumerator ErrorPopup()
        {
            waveActiveErrorText.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            waveActiveErrorText.gameObject.SetActive(false);
        }

        private void FirstAppear()
        {
            //adds enemies to the spawnable list based on theirs first appear wave
            foreach (var enemy in enemies)
            {
                if (enemy.firstAppear == currWave && !spawnableEnemies.Contains(enemy)) spawnableEnemies.Add(enemy);
            }
        }

        private void StartNewWave()
        {
            FirstAppear();
            startWaveText.enabled = false;
            waveActive = true;
            currWave++; 
            GenerateWave();
        }

        private void Win()
        {
            currWave = waveCount;
                winScreen.SetActive(true);
                _win.Win();
        }

        private void EndWave()
        {
            waveTimerText.text = "Wave not active";
            waveActive = false;
            waveTimer = waveDuration;
            startWaveText.enabled = true;
        }

    }

    [System.Serializable]
    public class Enemy
    {
        public GameObject enemyPrefab;
        public int cost;

        [Tooltip("The wave in what will this enemy first appear, set to zero to have this enemy start spawning from the first wave")]
        public int firstAppear;
    }
}
