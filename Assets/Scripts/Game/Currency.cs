using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Currency : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private SoundsManager _sounds;
    public int coins;
    public float health;


    private void Start()
    {
        StartCoroutine(PassiveCoinGain());
    }

    private void Update()
    {
        
        coinsText.text = coins.ToString();
        if (coins.ToString().Length > 6)
        {
            coinsText.fontSize = 20;
        }
        else if (coins.ToString().Length < 6)
        {
            coinsText.fontSize = 25;
        }
        healthText.text = health.ToString();

        if (health <=0)
        {
            health = 0;
            _sounds.GameOverSound();
        }
    }
    
    IEnumerator PassiveCoinGain()
    {
        yield return new WaitForSeconds(3);
        string diff = PlayerPrefs.GetString("difficulty");
        if (diff is "Novice" or "Journeyman")
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
    
    public void AddCoins(int amount)
    {
        coins += amount;
        coinsText.text = coins.ToString();
    }
    
}
