using UnityEngine;

namespace FG_NewBuildingSystem
{
    public class BuildingBehaviour : MonoBehaviour
    {
        public float maxHealth;
        public string buildingName;

        [HideInInspector] public float health;
        
        private void Start()
        {
            health = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        
        public void Repair(float repairAmount)
        {
            health += repairAmount;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }


    }
}


