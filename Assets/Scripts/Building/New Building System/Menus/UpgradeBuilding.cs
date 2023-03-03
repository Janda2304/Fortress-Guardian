using System;
using FG_EnemyAI;
using TMPro;
using UnityEngine;

namespace FG_NewBuildingSystem
{
    public class UpgradeBuilding : MonoBehaviour
    {

        public enum UpgradeType
        {
            Cannon,
            Fence
        }
       
        [Header("Options")]
        [Tooltip("The type of calculations this building would use (if both will be set to true the additive calculation would be used")]
        [SerializeField] private bool multiplicative;
        [Tooltip("The type of calculations this building would use (if both will be set to true the additive calculation would be used")]
        [SerializeField] private bool additive;
        [SerializeField] private bool useDefaultValue = true;
        public UpgradeType upgradeType;
        [Header("Buildings Scripts")]
        [SerializeField] private BuildingBehaviour _building;
        [SerializeField][Tooltip("Can be null if the enum upgrade is not set to Cannon")] private CannonAI _cannon;
        [Header("Upgrade General")]
        [SerializeField] private int upgradeCost;
        private int upgradeLevel;
        [SerializeField][Tooltip("max upgrade level for this building")] private int maxLevel;
        [Header("Multiplicative Upgrade Calculation")]
        [Tooltip("the default value for all additions, if others would be set to 0 with useDefaultValue set to true it will use this value")]
        [SerializeField] private float upgradeMultiplier;
        [SerializeField] private float upgradeCostMultiplier;
        [SerializeField] private float hpMultiplier;
        [SerializeField] private float damageMultiplier;
        [SerializeField] private float rangeMultiplier;
        [SerializeField] private float fireRateMultiplier;
        [Header("Additive Upgrade Calculation")]
        [Tooltip("the default value for all additions, if others would be set to 0 with useDefaultValue set to true it will use this value")] 
        [SerializeField] private float upgradeAdditive;
        [SerializeField] private float upgradeCostAdditive;
        [SerializeField] private float hpAdditive;
        [SerializeField] private float dmgAdditive;
        [SerializeField] private float rangeAdditive;
        [SerializeField] private float fireRateAdditive;
        [Header("Other")] 
        [SerializeField] private TMP_Text upgradeCostText;
        [SerializeField] private BuildingSoundsControl _sounds;
        [SerializeField] private WaveSpawner _wave;




        private void Start()
        {
            #region setup
            _wave = FindObjectOfType<WaveSpawner>();
            _sounds = FindObjectOfType<BuildingSoundsControl>();
            if (multiplicative && additive)
            {
                additive = true;
                multiplicative = false;
            }

            if (useDefaultValue)
            {
                if (multiplicative)
                {
                    if (hpMultiplier == 0) hpMultiplier = upgradeMultiplier;
                    if (damageMultiplier == 0) damageMultiplier = upgradeMultiplier;
                    if (rangeMultiplier == 0) rangeMultiplier = upgradeMultiplier;
                    if (fireRateMultiplier == 0) fireRateMultiplier = upgradeMultiplier;
                    if (upgradeCostMultiplier == 0) upgradeCostMultiplier = upgradeMultiplier;
                }
                else if (additive)
                {
                    if (hpAdditive == 0) hpAdditive = upgradeAdditive;
                    if (dmgAdditive == 0) dmgAdditive = upgradeAdditive;
                    if (rangeAdditive == 0) rangeAdditive = upgradeAdditive;
                    if (fireRateAdditive == 0) fireRateAdditive = upgradeAdditive;
                    if (upgradeCostAdditive == 0) upgradeCostAdditive = upgradeAdditive;
                }
            }
            #endregion
        }

        private void FixedUpdate()
        {
            upgradeCostText.text = upgradeCost.ToString();
        }
        public void Upgrade()
        {
            #region Multiplicative
            if (multiplicative)
            {
                if (upgradeLevel < maxLevel && !_wave.waveActive && Currency.Coins >= upgradeCost)
                {
                    Currency.PayCoins(upgradeCost);
                    upgradeLevel++;
                    upgradeCost = (int)(upgradeCost * upgradeCostMultiplier);
                    upgradeCostText.text = upgradeCost.ToString();
                    if (upgradeType == UpgradeType.Fence)
                    {
                        _building.maxHealth = (int)(_building.maxHealth * hpMultiplier);
                        _building.health = _building.maxHealth;
                    }
                    if (upgradeType == UpgradeType.Cannon)
                    {
                        _building.maxHealth = (int)(_building.maxHealth * hpMultiplier);
                        _building.health = _building.maxHealth;
                        _cannon.damage = (int)(_cannon.damage * damageMultiplier);
                        _cannon.range = (int)(_cannon.range * rangeMultiplier);
                        _cannon.fireRate = (int)(_cannon.fireRate * fireRateMultiplier);
                        print($"Damage: {_cannon.damage} Range: {_cannon.range} FireRate: {_cannon.fireRate} AttackRange: {_cannon.range}");
                    }
                    
                }
            }
            #endregion
            #region Additive
            else if (additive)
            {
                if (upgradeLevel < maxLevel && !_wave.waveActive && Currency.Coins >= upgradeCost)
                {
                    Currency.PayCoins(upgradeCost);
                    upgradeLevel++;
                    upgradeCost = (int)(upgradeCost + upgradeCostAdditive);
                    upgradeCostText.text = upgradeCost.ToString();
                    if (upgradeType == UpgradeType.Fence)
                    {
                        _building.maxHealth = (int)(_building.maxHealth + hpAdditive);
                        _building.health = _building.maxHealth;
                    }
                    
                    if (upgradeType == UpgradeType.Cannon)
                    {
                        _building.maxHealth = (int)(_building.maxHealth + hpAdditive);
                        _building.health = _building.maxHealth;
                        _cannon.damage = (int)(_cannon.damage + dmgAdditive);
                        _cannon.range = (int)(_cannon.range + rangeAdditive);
                        _cannon.fireRate = (int)(_cannon.fireRate + fireRateAdditive);
                        print($"Damage: {_cannon.damage} Range: {_cannon.range} FireRate: {_cannon.fireRate} AttackRange: {_cannon.range}");
                    }
                    
                }
            }
            #endregion
           
        }
    }
}