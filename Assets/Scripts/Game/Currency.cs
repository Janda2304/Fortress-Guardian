using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Currency : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text healthText;
    public int coins;
    public int health;


    private void FixedUpdate()
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
    }
}
