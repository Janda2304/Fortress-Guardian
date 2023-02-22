using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BayatGames.SaveGameFree;
using FG_NewBuildingSystem;
using UnityEngine;



namespace FG_Saving
{
    public class SaveManage : MonoBehaviour
    {
        [Header("Buildings")]
        public GameObject cannon;
        public GameObject fence;
        public static List<GameObject> buildings = new List<GameObject>();
        public List<Vector3> buildingPositions = new List<Vector3>();
        public List<Quaternion> buildingRotations = new List<Quaternion>();
        public BuildingData buildingData;
        private int buildIndex;
        [Header("Currency")] 
        public CurrencyData _currencyData;
        [Header("Others")] 
        public PauseManager _pause;
      


        private void Start()
        {
            SaveGame.Encode = true;
        }

        public void Save()
        {
            SaveBuildings();
            SaveCurrencies();
        }

        public void Load()
        {
            LoadBuildings();
            LoadCurrencies();
            _pause.Resume();
            PlayerMovement.loaded = true;
        }

        
        #region Buildings
        public void SaveBuildings()
        {
            buildingData.SaveData();
            SaveGame.Save("BuildingsData", buildingData, 1);
        }
        
        
        public void LoadBuildings()
        {
            buildings.Clear();
            buildings = GameObject.FindGameObjectsWithTag("Building").ToList();
            buildingPositions.Clear();
            buildingRotations.Clear();
            BuildingData bd = SaveGame.Load<BuildingData>("BuildingsData", 1);
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
            SaveGame.Save("CurrencyData", _currencyData, 1);
        }
    
        public void LoadCurrencies()
        {
            _currencyData.LoadCurrencyData();
            CurrencyData currencyData = SaveGame.Load<CurrencyData>("CurrencyData", 1);
            Currency.Coins = currencyData.coins;
            Currency.Health = currencyData.health;
        }

        #endregion
        
    }
}
