using System;
using FG_EnemyAI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace FG_NewBuildingSystem
{
    public class BuildingMenus : MonoBehaviour
    {
        [Header("Crosshairs")]
        [SerializeField] private Image crosshair;
        [SerializeField] private Sprite defaultCrosshair;
        [SerializeField] private Sprite upgradeCrosshair;
        [SerializeField] private Sprite sellCrosshair;
        [SerializeField] private Sprite repairCrosshair;
        [SerializeField] private float range = 3f;
        [Header("Keys")] 
        [SerializeField] private KeyCodes keyCodes;
        [Header("Other Scripts")]
        [SerializeField] private BuildingSystem _buildingSystem;
        public Action upgradeAction;
        [Header("Others")] 
        [SerializeField] private Camera playerCam;
        [Header("Prices")] 
        [SerializeField] private TMP_Text upgradePrice;
        [SerializeField] private TMP_Text sellPrice;
        [SerializeField] private TMP_Text repairPrice;

        public enum Action
        {
            None,
            Upgrade,
            Sell,
            Repair
        }

        private bool isUpgrading;
        private bool isSelling;
        private bool isRepairing;
        public bool buildingSelected;

        private void Start()
        {
            upgradeAction = Action.None;
        }


        void Update()
        {
            
            if (Input.GetKeyDown(keyCodes.upgradeKey) && !isUpgrading)
            {
                crosshair.sprite = upgradeCrosshair;
                upgradeAction = Action.Upgrade;
                isUpgrading = true;
            }
            else if (Input.GetKeyDown(keyCodes.upgradeKey) && isUpgrading)
            {
                crosshair.sprite = defaultCrosshair;
                upgradeAction = Action.None;
                isUpgrading = false;
            }

            if (Input.GetKeyDown(keyCodes.sellKey) && !isSelling)
            {
                crosshair.sprite = sellCrosshair;
                upgradeAction = Action.Sell;
                isSelling = true;
            }
            else if (Input.GetKeyDown(keyCodes.sellKey) && isSelling)
            {
                crosshair.sprite = defaultCrosshair;
                upgradeAction = Action.None;
                isSelling = false;
            }

            if (Input.GetKeyDown(keyCodes.repairKey) && !isRepairing)
            {
                crosshair.sprite = repairCrosshair;
                isRepairing = true;
                upgradeAction = Action.Repair;
            }
            else if (Input.GetKeyDown(keyCodes.repairKey) && isRepairing)
            {
                crosshair.sprite = defaultCrosshair;
                isRepairing = false;
                upgradeAction = Action.None;
            }
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, range))
            {

                if (hit.transform.parent.CompareTag("Building"))
                {
                    buildingSelected = true;

                    if (Input.GetButtonDown("Fire1") && (isRepairing || isSelling || isUpgrading))
                    {
                        switch (upgradeAction)
                        {
                            case Action.Upgrade:
                                Upgrade(hit);
                                break;
                            case Action.Sell:
                                Sell(hit);
                                break;
                            case Action.Repair:
                                Repair(hit);
                                break;
                        }
                    }
                }
                else buildingSelected = false;


            }
            else buildingSelected = false;
            
           

        }

        void Upgrade(RaycastHit hit)
        {
            hit.transform.GetComponentInChildren<UpgradeBuilding>().Upgrade();
        }

        void Sell(RaycastHit hit)
        {
            hit.transform.GetComponentInChildren<SellBuilding>().StartCoroutine(nameof(SellBuilding.Sell));
        }

        void Repair(RaycastHit hit)
        {
            hit.transform.GetComponentInChildren<RepairBuilding>().StartCoroutine(nameof(RepairBuilding.Repair));
        }
        
      
        
        
    }
}

[System.Serializable]
public struct KeyCodes
{
    public KeyCode upgradeKey;
    public KeyCode sellKey;
    public KeyCode repairKey;
    
}
