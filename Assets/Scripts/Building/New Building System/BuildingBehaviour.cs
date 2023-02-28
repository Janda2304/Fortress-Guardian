using System;
using System.Collections;
using System.Collections.Generic;
using FG_NewBuildingSystem;
using UnityEngine;

namespace FG_NewBuildingSystem
{
    public class BuildingBehaviour : MonoBehaviour
    {
        public float maxHealth;
        public string buildingName;
        public static float maxHealthReadOnly;
   
        [HideInInspector] public float health;
        
        private void Start()
        {
            maxHealthReadOnly = maxHealth;
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
    }
}


