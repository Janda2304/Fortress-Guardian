using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FG_NewBuildingSystem
{
    public class BuildingHealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private TMP_Text healthNumber;
        [SerializeField] private BuildingBehaviour _building;
        [SerializeField] private Transform healthBarRect;
        [SerializeField] private Camera mainCamera;
        private float fill;
  


        private void Start()
        {
            mainCamera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Camera>();
        }

        private void Update()
        {
            fill = _building.health / _building.maxHealth;
            healthBar.fillAmount = fill;
            healthBarRect.LookAt(mainCamera.transform);
            healthNumber.text = $"{_building.health}/{_building.maxHealth}";
        }
  
    }


}

