using System.Collections;
using FG_EnemyAI;
using TMPro;
using UnityEngine;

namespace FG_NewBuildingSystem
{
    public class RepairBuilding : MonoBehaviour
    {
        [SerializeField] private float baseRepairPrice;
        private float repairCost;
        private int repairCostInt;
        [SerializeField] private BuildingBehaviour _building;
        [SerializeField] private TMP_Text repairPriceText;
        [SerializeField] private BuildingSoundsControl _sounds;
        [SerializeField] private WaveSpawner _wave;


        private void Start()
        {
            _sounds = FindObjectOfType<BuildingSoundsControl>();
            _wave = FindObjectOfType<WaveSpawner>();
        }

        private void FixedUpdate()
        {
            float dmgSustained = _building.maxHealth - _building.health;
            repairCost = dmgSustained * baseRepairPrice;
            print(repairCost);
            repairCostInt = Mathf.RoundToInt(repairCost);
            repairPriceText.text = repairCostInt.ToString();
        }

        private void OnMouseDown()
        {
            print("mouse down");
            StartCoroutine(Repair());
        }

        public IEnumerator Repair()
        {
            repairCost = baseRepairPrice * _building.health / _building.maxHealth;
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



