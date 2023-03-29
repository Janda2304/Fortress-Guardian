using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using FG_EnemyAI;

public class Currency : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text healthText;

    [Header("Other Scripts")]
    [SerializeField] private WaveSpawner _wave;
    [SerializeField] private PauseManager _pause;
    [SerializeField] private SoundsManager _sounds;
    [Header("Menus")]
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject gameUI;
    public static int Coins;
    public static float Health;
    public static bool IsGameLost;


    private void Start()
    {
       
        #region difficulty
        string difficulty = PlayerPrefs.GetString("difficulty");
        switch (difficulty)
        {
            case "Novice":
                Setup(75,400);
                break;
            case "Journeyman":
                Setup(50, 350);
                break;
            case "Master":
                Setup(25,250);
                break;
        }
        #endregion
        StartCoroutine(PassiveCoinGain());
        deathScreen.SetActive(false);
        _pause.Resume();
    }

    private void Update()
    {
        coinsText.text = Coins.ToString();
        healthText.text = Health.ToString();

        if (Health <=0)
        {
            IsGameLost = true;
            _pause.Pause();
            Health = 0;
            //_sounds.GameOverSound();
            deathScreen.SetActive(true);
            pauseScreen.SetActive(false);
            gameUI.SetActive(false);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
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

    public void ContinuePlaying()
    {
        IsGameLost = false;
        _pause.Resume();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AutoLoad.Enabled = false;
    }
    
    public void MainMenu()
    {
        IsGameLost = false;
        deathScreen.SetActive(false);
        _pause.Resume();
        SceneManager.LoadScene("MainMenu");
    }
    
    private void Setup(float health, int coins)
    {
       Health = health;
       Coins = coins;
    }
    


}
