using System.Collections;
using FG_CustomFunctions;
using FG_EnemyAI;
using TMPro;
using UnityEngine;

namespace FG_NewBuildingSystem
{
    public class RepairBuilding : MonoBehaviour
    {
        [SerializeField] private float baseRepairPrice;
        public float repairCost;
        private int repairCostInt;
        [SerializeField] private BuildingBehaviour _building;
        public TMP_Text repairPriceText;
        [SerializeField] private BuildingSoundsControl _sounds;
        [SerializeField] private WaveSpawner _wave;
        [SerializeField] private BuildingMenus _buildingActions;


        private void Start()
        {
            _sounds = FindObjectOfType<BuildingSoundsControl>();
            _wave = FindObjectOfType<WaveSpawner>();
            repairPriceText = GameObjectC.FindObjectByName("RepairPrice").GetComponent<TMP_Text>();
            _buildingActions = FindObjectOfType<BuildingMenus>();
        }

        private void FixedUpdate()
        {
            if (_building.health == _building.maxHealth)
            {
                repairCost = 0;
                repairCostInt = 0;
                
            }
            float dmgSustained = _building.maxHealth - _building.health;
            repairCost = dmgSustained * baseRepairPrice;
            repairCostInt = Mathf.RoundToInt(repairCost);
            repairPriceText.text = repairCostInt.ToString();
            if (_buildingActions.upgradeAction == BuildingMenus.Action.Repair)
            {
                repairPriceText.text = repairCostInt.ToString();
                repairPriceText.gameObject.SetActive(_buildingActions.buildingSelected);
            }
            else repairPriceText.gameObject.SetActive(false);
            
        }

      

        public IEnumerator Repair()
        {
            repairCost = baseRepairPrice * _building.health / _building.maxHealth;
            print($"baseRepair {baseRepairPrice}\n health/maxHealth {_building.health / _building.maxHealth}\n final cost: {repairCost}\n");
            repairCostInt = Mathf.RoundToInt(repairCost);
            yield return new WaitForSeconds(1f);
            if (repairCostInt <= Currency.Coins && !_wave.waveActive)
            {
                print(repairCostInt);
                Currency.PayCoins(repairCostInt);
                _building.health = _building.maxHealth;
            }
            else if (repairCostInt > Currency.Coins || repairCostInt == 0 || _wave.waveActive)
            {
                _sounds.PlayErrorSound();
            }


        }

    }
}



