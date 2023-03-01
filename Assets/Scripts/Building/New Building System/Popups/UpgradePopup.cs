using UnityEngine;

namespace FG_NewBuildingSystem
{
    public class UpgradePopup : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private BuildingBehaviour _building;

        private void Start()
        {
            canvas.worldCamera = FindObjectOfType<Camera>();
        }

        private void OnMouseDown()
        {
            
        }
    }
}