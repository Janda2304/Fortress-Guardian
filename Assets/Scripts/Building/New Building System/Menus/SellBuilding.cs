using System;
using System.Collections;
using TMPro;
using UnityEngine;
using FG_CustomFunctions;

namespace FG_NewBuildingSystem
{
    public class SellBuilding : MonoBehaviour
    {
        [SerializeField] private int baseSellPrice;
        public float sellPrice;
        private int sellPriceAmount;
        [SerializeField] private BuildingBehaviour _building;
        public TMP_Text sellGainText;
        [SerializeField] private UpgradeBuilding _upgrade;
        [SerializeField] private BuildingMenus _buildingActions;
       
        [Tooltip("The value that the price of all bought upgrades will be dived by to get the final sell price")] 
        [SerializeField] private float sellByUpgradeMultiplier;

        private void Start()
        { 
            sellGainText = GameObjectC.FindObjectByName("SellPrice").GetComponent<TMP_Text>(); 
            _buildingActions = FindObjectOfType<BuildingMenus>();
        }

        private void FixedUpdate()
        {
           
            sellPrice = (baseSellPrice * _building.health / _building.maxHealth) + _upgrade.sumPrice / sellByUpgradeMultiplier;
            sellPriceAmount = Mathf.RoundToInt(sellPrice);
            sellGainText.text = "+" + sellPriceAmount;
            if (_buildingActions.upgradeAction == BuildingMenus.Action.Sell)
            {
                sellGainText.text = "+" + sellPriceAmount;
                sellGainText.gameObject.SetActive(_buildingActions.buildingSelected);
            }
            else sellGainText.gameObject.SetActive(false);
        }

        public IEnumerator Sell()
        {
            sellPrice = baseSellPrice * _building.health / _building.maxHealth;
            sellPriceAmount = Mathf.RoundToInt(sellPrice);
            yield return new WaitForSeconds(1f);
            Currency.AddCoins(sellPriceAmount);
            Destroy(_building.gameObject);
        }
    
    }

}

