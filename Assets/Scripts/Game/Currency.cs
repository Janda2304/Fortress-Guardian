using System;
using System.Collections;
using BayatGames.SaveGameFree;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Currency : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private SoundsManager _sounds;
    public static int Coins;
    public static float Health;
    [SerializeField] private WaveSpawner _wave;
    [SerializeField] private GameObject deathScreen;
    private static Scene scene;


    private void Start()
    {
        scene = SceneManager.GetSceneByName("Game");
        #region difficulty
        string difficulty = PlayerPrefs.GetString("difficulty");
        if (difficulty == "Novice")
        {
            Coins = 400;
            Health = 75;
        }
        else if (difficulty == "Journeyman")
        {
            Coins = 350;
            Health = 50;
        }
        else if (difficulty == "Master")
        {
            Coins = 250;
            Health = 25;
        }
        #endregion
        StartCoroutine(PassiveCoinGain());
    }

    private void Update()
    {
        coinsText.text = Coins.ToString();
        healthText.text = Health.ToString();

        if (Health <=0)
        {
            Health = 0;
            _sounds.GameOverSound();
            deathScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
    
    IEnumerator PassiveCoinGain()
    {
            yield return new WaitForSeconds(3);
            string diff = PlayerPrefs.GetString("difficulty");
            if (diff is "Novice" or "Journeyman" && _wave.waveActive)
            {
                StartCoroutine(PassiveCoinGain());
                if (diff is "Novice")
                {
                    AddCoins(10);
                }
                else
                {
                    AddCoins(5);
                }
            
            }
            else
            {
                StartCoroutine(PassiveCoinGain());
            }
    }
    
    public static void AddCoins(int amount)
    {
        Coins += amount;
    }
    
    public static void PayCoins(int amount)
    {
        Coins -= amount;
    }
    
    public static void Regenerate(float amount)
    {
        Health += amount;
    }
    
    public static void TakeDamage(float amount)
    {
        Health -= amount;
    }

    public static void Save()
    {
        SaveGame.Encode = true;
        
        SaveGame.Save("Coins", Coins, 1);
        SaveGame.Save("Health", Health, 1);
    }


}
