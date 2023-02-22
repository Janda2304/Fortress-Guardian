using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


namespace FG_EnemyAI
{


    public class WaveSpawner : MonoBehaviour
    {
        [Header("UI")] [SerializeField] private TMP_Text waveTimerText;
        [SerializeField] private TMP_Text waveNumberText;
        [SerializeField] private TMP_Text waveActiveErrorText;

        [Header("Wave Settings")] private int currWave;
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

        private void Start()
        {
            waveActiveErrorText.text = "Wave is already active!";
            waveActiveErrorText.gameObject.SetActive(false);
        }

        private void Update()
        {
            foreach (var enemy in enemies)
            {
                if (enemy.firstAppear == currWave && !spawnableEnemies.Contains(enemy))
                {
                    spawnableEnemies.Add(enemy);
                }
            }

            if (!waveActive)
            {
                waveTimerText.text = "Wave not active";
            }
            else
            {
                waveTimerText.text = $"{decimal.Round(Convert.ToDecimal(waveTimer), 1)}s";
            }

            waveNumberText.text = $"{currWave}/{waveCount}";
            if (Input.GetKeyDown(KeyCode.L) && !waveActive && currWave < waveCount)
            {
                waveActive = true;
                currWave++;
                GenerateWave();
            }
            else if (Input.GetKeyDown(KeyCode.L) && waveActive)
            {
                StartCoroutine(ErrorPopup());
            }

            if (spawnedEnemies.Count == 0 && waveActive && waveTimer < waveDuration - spawnInterval)
            {
                waveActive = false;
                waveTimer = waveDuration;
            }



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
                    GameObject enemy = Instantiate(enemiesToSpawn[0], spawnLocation[spawnIndex].position,
                        Quaternion.identity);
                    enemiesToSpawn.RemoveAt(0);
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

            if (waveTimer <= 0 && waveActive)
            {
                currWave++;
                GenerateWave();
            }

            if (spawnedEnemies.Count == 0 && waveActive && waveTimer < waveDuration - spawnInterval)
            {
                waveActive = false;
                waveTimer = waveDuration;
            }

        }

        public void GenerateWave()
        {
            waveValue = currWave * waveValueIncrease;
            GenerateEnemies();

            spawnInterval = currWave / 1f;
            waveTimer = waveDuration;
        }

        public void GenerateEnemies()
        {


            List<GameObject> generatedEnemies = new List<GameObject>();
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

            enemiesToSpawn.Clear();
            enemiesToSpawn = generatedEnemies;
        }

        private IEnumerator ErrorPopup()
        {
            waveActiveErrorText.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            waveActiveErrorText.gameObject.SetActive(false);
        }

    }

    [System.Serializable]
    public class Enemy
    {
        public GameObject enemyPrefab;
        public int cost;

        [Tooltip(
            "The wave in what will this enemy first appear, set to zero to have this enemy start spawning from the first wave")]
        public int firstAppear;
    }
}
