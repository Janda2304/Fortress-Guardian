using System;
using System.Collections;
using System.Collections.Generic;
using FG_NewBuildingSystem;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SellPopup : MonoBehaviour
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

    private void OnMouseDown()
    {
        print("mouse down");
        StartCoroutine(Sell());
    }

    private IEnumerator Sell()
    {
        sellPrice = baseSellPrice * _building.health / _building.maxHealth;
        sellPriceAmount = Mathf.RoundToInt(sellPrice);
        yield return new WaitForSeconds(1f);
        Currency.AddCoins(sellPriceAmount);
        Destroy(_building.gameObject);
    }
    
}
