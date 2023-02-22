using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Currency Data", menuName = "Currency Data")]
public class CurrencyData : ScriptableObject
{
    public int coins;
    public float health;
    


    public void SaveCurrencyData()
    {
        coins = Currency.Coins;
        health = Currency.Health;
    }
    
    public void LoadCurrencyData()
    {
        Currency.Coins = coins;
        Currency.Health = health;
    }
}
