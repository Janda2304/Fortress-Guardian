using System;
using FG_CustomFunctions;
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
        public int upgradeCost;
        private int upgradeLevel;
        [SerializeField][Tooltip("max upgrade level for this building")] private int maxLevel;

        [Header("Multiplicative Upgrade Calculation")]
        [SerializeField] private MultiplicativeUpgrade multiplicativeUpgrade;
        
        [Header("Additive Upgrade Calculation")]
        [SerializeField] private AdditiveUpgrade additiveUpgrade;
        
        [Header("Other")] 
        public TMP_Text upgradeCostText;
        [SerializeField] private BuildingSoundsControl _sounds;
        [SerializeField] private WaveSpawner _wave;
        [SerializeField] private BuildingMenus _buildingActions;

        public int sumPrice;




        private void Start()
        {
            #region setup
            upgradeCostText = GameObjectC.FindObjectByName("UpgradePrice").GetComponent<TMP_Text>();
            _sounds = FindObjectOfType<BuildingSoundsControl>();
            _buildingActions = FindObjectOfType<BuildingMenus>();
            _wave = FindObjectOfType<WaveSpawner>();
            if (multiplicative && additive)
            {
                additive = true;
                multiplicative = false;
            }

            if (useDefaultValue)
            {
                if (multiplicative)
                {
                    MultiplicativeUpgrade mu = multiplicativeUpgrade;
                    if (mu.hpMultiplier == 0) mu.hpMultiplier = mu.upgradeMultiplier;
                    if (mu.dmgMultiplier == 0) mu.dmgMultiplier = mu.upgradeMultiplier;
                    if (mu.rangeMultiplier == 0) mu.rangeMultiplier = mu.upgradeMultiplier;
                    if (mu.fireRateMultiplier == 0) mu.fireRateMultiplier = mu.upgradeMultiplier;
                    if (mu.upgradeCostMultiplier == 0) mu.upgradeCostMultiplier = mu.upgradeMultiplier;
                    multiplicativeUpgrade = mu;
                }
                else if (additive)
                {
                    AdditiveUpgrade au = additiveUpgrade;
                    if (au.hpAdditive == 0) au.hpAdditive = au.upgradeAdditive;
                    if (au.dmgAdditive == 0) au.dmgAdditive = au.upgradeAdditive;
                    if (au.rangeAdditive == 0) au.rangeAdditive = au.upgradeAdditive;
                    if (au.fireRateAdditive == 0) au.fireRateAdditive = au.upgradeAdditive;
                    if (au.upgradeCostAdditive == 0) au.upgradeCostAdditive = au.upgradeAdditive;
                    additiveUpgrade = au;
                }
            }
            #endregion
        }

        private void FixedUpdate()
        {
            upgradeCostText.text = upgradeCost.ToString();
            if (_buildingActions.upgradeAction == BuildingMenus.Action.Upgrade)
            {
                upgradeCostText.text = upgradeCost.ToString();
                upgradeCostText.gameObject.SetActive(_buildingActions.buildingSelected);
            }
            else upgradeCostText.gameObject.SetActive(false);
        }
        public void Upgrade()
        {
            #region Multiplicative
            if (multiplicative)
            {
                if (upgradeLevel < maxLevel && !_wave.waveActive && Currency.Coins >= upgradeCost)
                {
                    Currency.PayCoins(upgradeCost);
                    sumPrice += upgradeCost;
                    upgradeLevel++;
                    upgradeCost = (int)(upgradeCost * multiplicativeUpgrade.upgradeCostMultiplier);
                    upgradeCostText.text = upgradeCost.ToString();
                    if (upgradeType == UpgradeType.Fence)
                    {
                        _building.maxHealth = (int)(_building.maxHealth * multiplicativeUpgrade.hpMultiplier);
                        _building.health = _building.maxHealth;
                    }
                    if (upgradeType == UpgradeType.Cannon)
                    {
                        _building.maxHealth = (int)(_building.maxHealth * multiplicativeUpgrade.hpMultiplier);
                        _building.health = _building.maxHealth;
                        _cannon.damage = (int)(_cannon.damage * multiplicativeUpgrade.dmgMultiplier);
                        _cannon.range = (int)(_cannon.range * multiplicativeUpgrade.rangeMultiplier);
                        _cannon.fireRate = (int)(_cannon.fireRate * multiplicativeUpgrade.fireRateMultiplier);
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
                    upgradeCost = (int)(upgradeCost + additiveUpgrade.upgradeCostAdditive);
                   // upgradeCostText.text = upgradeCost.ToString();
                    if (upgradeType == UpgradeType.Fence)
                    {
                        _building.maxHealth = (int)(_building.maxHealth + additiveUpgrade.hpAdditive);
                        _building.health = _building.maxHealth;
                    }
                    
                    if (upgradeType == UpgradeType.Cannon)
                    {
                        _building.maxHealth = (int)(_building.maxHealth + additiveUpgrade.hpAdditive);
                        _building.health = _building.maxHealth;
                        _cannon.damage = (int)(_cannon.damage + additiveUpgrade.dmgAdditive);
                        _cannon.range = (int)(_cannon.range + additiveUpgrade.rangeAdditive);
                        _cannon.fireRate = (int)(_cannon.fireRate + additiveUpgrade.fireRateAdditive);
                        print($"Damage: {_cannon.damage} Range: {_cannon.range} FireRate: {_cannon.fireRate} AttackRange: {_cannon.range}");
                    }
                    
                }
            }
            #endregion
           
        }
    }
}

[System.Serializable]

public struct AdditiveUpgrade
{
    [Tooltip("the default value for all additions, if others would be set to 0 with useDefaultValue set to true it will use this value")] 
    public float upgradeAdditive;
    public float upgradeCostAdditive;
    public float hpAdditive;
    public float dmgAdditive;
    public float rangeAdditive;
    public float fireRateAdditive;
}

[System.Serializable]

public struct MultiplicativeUpgrade
{
    [Tooltip("the default value for all multiplier, if others would be set to 0 with useDefaultValue set to true it will use this value")] 
    public float upgradeMultiplier;
    public float upgradeCostMultiplier;
    public float hpMultiplier;
    public float dmgMultiplier;
    public float rangeMultiplier;
    public float fireRateMultiplier;
}