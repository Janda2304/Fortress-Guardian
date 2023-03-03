using System.Collections;
using TMPro;
using UnityEngine;

namespace FG_NewBuildingSystem
{
    public class SellBuilding : MonoBehaviour
    {
        [SerializeField] private int baseSellPrice;
        private float sellPrice;
        private int sellPriceAmount;
        [SerializeField] private BuildingBehaviour _building;
        [SerializeField] private TMP_Text sellGainText;


        private void FixedUpdate()
        {
            sellPrice = baseSellPrice * _building.health / _building.maxHealth;
            sellPriceAmount = Mathf.RoundToInt(sellPrice);
            sellGainText.text = "+" + sellPriceAmount;
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

