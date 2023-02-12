using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FG_BuildingSystem
{
    public class BuildingBehaviour : MonoBehaviour
    {
        public float maxHealth;
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
    }
}


