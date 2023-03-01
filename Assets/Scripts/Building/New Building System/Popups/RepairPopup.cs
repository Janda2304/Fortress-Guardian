using System;
using System.Collections;
using System.Collections.Generic;
using FG_NewBuildingSystem;
using TMPro;
using UnityEngine;

public class RepairPopup : MonoBehaviour
{
    [SerializeField] private float baseRepairPrice;
    private float repairCost;
    private int repairCostInt;
    [SerializeField] private BuildingBehaviour _building;
    [SerializeField] private TMP_Text repairPriceText;
    [SerializeField] private BuildingSoundsControl _sounds;


    private void Start()
    {
        _sounds = FindObjectOfType<BuildingSoundsControl>();
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

    private IEnumerator Repair()
    {
        repairCost = baseRepairPrice * _building.health / _building.maxHealth;
        repairCostInt = Mathf.RoundToInt(repairCost);
        yield return new WaitForSeconds(1f);
        if (repairCostInt <= Currency.Coins)
        {
            print(repairCostInt);
            Currency.PayCoins(repairCostInt);
            _building.health = _building.maxHealth;
        }
        else if (repairCostInt > Currency.Coins || repairCostInt == 0)
        {
            _sounds.PlayErrorSound();
        }
       
        
    }
}
