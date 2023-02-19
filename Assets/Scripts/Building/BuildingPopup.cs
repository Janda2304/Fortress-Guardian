using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FG_BuildingSystem
{


    public class BuildingPopup : MonoBehaviour
    {
        [SerializeField] private GameObject building; /* till i make a better way to get prices*/
        [SerializeField] private GameObject popup;
        [SerializeField] private Transform popupRect;
        [SerializeField] private Camera playerCamera;
        [SerializeField] private LayerMask buildingLayer;
        [SerializeField][Range(0.1f, 15)][Tooltip("A range in what the popup will show")] private float range = 5f;
        private int sellPrice;
        [SerializeField] private BuildingPlacementControl _control; /*till i make a better way to get prices*/
        [SerializeField] private Currency _currency; //TODO: make a new currency system
        
        private void Start()
        {
            playerCamera = FindObjectOfType<Camera>();
            _control = FindObjectOfType<BuildingPlacementControl>();
            _currency = FindObjectOfType<Currency>();
            sellPrice = _control.prices[building.name];
        } 

        void Update()
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range, buildingLayer))
            {
                popup.SetActive(true);
                //popupRect.LookAt(playerCamera.transform);
            
            }
            else
            {
                popup.SetActive(false);
            }
        
            
        
        }
        
        public void Upgrade()
        {

        }

        public IEnumerator Sell()
        {
            _currency.coins += sellPrice;
            yield return new WaitForSeconds(1);
            Destroy(building);

        }
    }
}