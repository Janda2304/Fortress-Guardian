using System.Collections;
using System.Collections.Generic;
using BayatGames.SaveGameFree;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [Header("Player")] 
    public PlayerData _playerData;
    public GameObject player;
    public PauseManager _pause;
    [Header("Game")]
    public CurrencyData _currencyData;
   


    private void Start()
    {
        SaveGame.Encode = true;
    }


    public void Save()
    {
        SavePlayer();
        SaveCurrencies();
    }

    public void Load()
    {
      LoadPlayer();
      LoadCurrencies();
    }



    public void SavePlayer()
    {
        _playerData.SavePlayerData(player);
        SaveGame.Save("PlayerData", _playerData, 1);
    }

    public void SaveCurrencies()
    {
        _currencyData.SaveCurrencyData();
    }
    
    public void LoadCurrencies()
    {
        _currencyData.LoadCurrencyData();
    }
    
    public void LoadPlayer()
    { 
        PlayerData playerData = SaveGame.Load<PlayerData>("PlayerData", 1); 
        playerData.LoadPlayerData(player);
        playerData.SavePlayerData(player);
        _pause.Resume();
        PlayerMovement.loaded = false;
    }
    
    
    
    
  
   
}
