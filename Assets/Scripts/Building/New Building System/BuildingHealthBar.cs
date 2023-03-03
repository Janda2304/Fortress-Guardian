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
        [SerializeField] private GameObject player;
        private float fill;
  


        private void Start()
        {
            mainCamera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Camera>();
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            fill = _building.health / _building.maxHealth;
            healthBar.fillAmount = fill;
            healthBarRect.LookAt(player.transform);
            healthNumber.text = $"{_building.health}/{_building.maxHealth}";
        }
  
    }


}

