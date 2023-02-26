using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BayatGames.SaveGameFree;
using FG_EnemyAI;
using FG_NewBuildingSystem;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace FG_Saving
{
    public class SaveManage : MonoBehaviour
    {
        [Header("Buildings")]
        public GameObject cannon;
        public GameObject fence;
        public List<GameObject> buildings = new List<GameObject>();
        public List<Vector3> buildingPositions = new List<Vector3>();
        public List<Quaternion> buildingRotations = new List<Quaternion>();
        public BuildingData buildingData;
        private int buildIndex;
        [Header("LevelData")] 
        public CurrencyData _currencyData;
        public LevelData _levelData;
        private bool sceneLoaded;
        [Header("Other scripts")] 
        public PauseManager _pause;
        public WaveSpawner _waveSpawner;
        

        public static int saveFile = 0;
      


        private void Start()
        {
            SaveGame.Encode = true;
            saveFile = PlayerPrefs.GetInt("SaveFile");
            PlayerPrefs.SetInt("SaveFile", saveFile);
        }

        public void Save()
        {
            if (!_waveSpawner.waveActive)
            {
                SaveBuildings();
                SaveLevel();
                SaveCurrencies();
            }
        
        }



        
        public void Load()
        {
            if (!_waveSpawner.waveActive)
            {
                if (SaveGame.Exists("LevelData", saveFile))
                {
                    LoadLevel();
                }


                if (SaveGame.Exists("CurrencyData", saveFile))
                {
                    LoadCurrencies();
                }


                if (SaveGame.Exists("BuildingsData", saveFile))
                {
                    LoadBuildings();
                }

                if (SceneManager.GetActiveScene().name != "MainMenu")
                {
                    _pause.Resume();
                }
         
                PlayerMovement.loaded = true;
            }
            
        }

      

        
        #region Buildings
        public void SaveBuildings()
        {
            buildingData.SaveData();
            SaveGame.Save("BuildingsData", buildingData, saveFile);
        }
        
        
        public void LoadBuildings()
        {
            buildings.Clear();
            buildings = GameObject.FindGameObjectsWithTag("Building").ToList();
            buildingPositions.Clear();
            buildingRotations.Clear();
            BuildingData bd = SaveGame.Load<BuildingData>("BuildingsData", saveFile);
            buildIndex = 0; 
            foreach (var building in buildings)
            {
                Destroy(building);
            }

            foreach (var building in bd.savedBuildings)
            {
                if (building == "Cannon")
                {
                    GameObject go = Instantiate(cannon, bd.savedBuildingPositions[buildIndex], bd.savedBuildingRotations[buildIndex]);
                    go.GetComponent<BuildingBehaviour>().health = bd.savedBuildingHealth[buildIndex];
                    buildIndex++; 
                }
                else if (building == "Fence")
                {
                    GameObject go =  Instantiate(fence, bd.savedBuildingPositions[buildIndex], bd.savedBuildingRotations[buildIndex]);
                    go.GetComponent<BuildingBehaviour>().health = bd.savedBuildingHealth[buildIndex];
                    buildIndex++; 
                }
                if (buildIndex >= bd.savedBuildings.Count) 
                {
                    break; 
                }
            }
        }
        #endregion

        #region Currency

        public void SaveCurrencies()
        {
            _currencyData.SaveCurrencyData();
            SaveGame.Save("CurrencyData", _currencyData, saveFile);
        }
    
        public void LoadCurrencies()
        {
            _currencyData.LoadCurrencyData();
            CurrencyData currencyData = SaveGame.Load<CurrencyData>("CurrencyData", saveFile);
            Currency.Coins = currencyData.coins;
            Currency.Health = currencyData.health;
        }

        #endregion
        
        #region LevelData

        public void SaveLevel()
        {
            _levelData.SaveLevelData();
            SaveGame.Save("LevelData", _levelData, saveFile);
         
        }
        
        public void LoadLevel()
        {
            LevelData levelData = SaveGame.Load<LevelData>("LevelData", saveFile);
            levelData.LoadLevelData();
        }
        
        #endregion
        
    }
}
