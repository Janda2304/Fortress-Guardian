using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingHealthBar : MonoBehaviour
{
  [SerializeField] private Image healthBar;
  [SerializeField] private TMP_Text healthNumber;
  [SerializeField] private BuildingBehaviour buildingBehaviour;
  [SerializeField] private Transform healthBarRect;
  [SerializeField] private Camera mainCamera;
  private float fill;
  


  private void Start()
  {
    mainCamera = FindObjectOfType<Camera>();
  }

  private void Update()
  {
    fill = buildingBehaviour.health / buildingBehaviour.maxHealth;
    healthBar.fillAmount = fill;
    healthBarRect.LookAt(mainCamera.transform);
    healthNumber.text = $"{buildingBehaviour.health}/{buildingBehaviour.maxHealth}";
  }
  
}


