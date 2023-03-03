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
        [SerializeField] private KeyCode upgradeKey = KeyCode.G;
        [SerializeField] private KeyCode sellKey = KeyCode.Q;
        [SerializeField] private KeyCode repairKey = KeyCode.T;
        [Header("Other Scripts")]
        [SerializeField] private BuildingSystem _buildingSystem;
        private Action upgradeAction;
        [Header("Others")] 
        [SerializeField] private Camera playerCam;

        private enum Action
        {
            None,
            Upgrade,
            Sell,
            Repair
        }

        private bool isUpgrading;
        private bool isSelling;
        private bool isRepairing;
        

        void Update()
        {
          
            if (Input.GetKeyDown(upgradeKey) && !isUpgrading)
            {
                crosshair.sprite = upgradeCrosshair;
                upgradeAction = Action.Upgrade;
                isUpgrading = true;
            }
            else if (Input.GetKeyDown(upgradeKey) && isUpgrading)
            {
                crosshair.sprite = defaultCrosshair;
                upgradeAction = Action.None;
                isUpgrading = false;
            }

            if (Input.GetKeyDown(sellKey) && !isSelling)
            {
                crosshair.sprite = sellCrosshair;
                upgradeAction = Action.Sell;
                isSelling = true;
            }
            else if (Input.GetKeyDown(sellKey) && isSelling)
            {
                crosshair.sprite = defaultCrosshair;
                upgradeAction = Action.None;
                isSelling = false;
            }

            if (Input.GetKeyDown(repairKey) && !isRepairing)
            {
                crosshair.sprite = repairCrosshair;
                isRepairing = true;
                upgradeAction = Action.Repair;
            }
            else if (Input.GetKeyDown(repairKey) && isRepairing)
            {
                crosshair.sprite = defaultCrosshair;
                isRepairing = false;
                upgradeAction = Action.None;
            }
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, range))
            {
                if (hit.transform.CompareTag("Building"))
                {
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
             
            }
            
           

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
