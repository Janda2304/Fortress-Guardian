
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FG_EnemyAI
{


    public class EnemyHealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private TMP_Text healthNumber;
        [SerializeField] private EnemyAI _enemy;
        [SerializeField] private Transform healthBarRect;
        [SerializeField] private Camera mainCamera;
        private float fill;



        private void Start()
        {
            mainCamera = FindObjectOfType<Camera>();
        }

        private void Update()
        {
            fill = _enemy.health / _enemy.maxHealth;
            healthBar.fillAmount = fill;
            healthBarRect.LookAt(mainCamera.transform);
            healthNumber.text = $"{_enemy.health}/{_enemy.maxHealth}";
        }
    }
}

