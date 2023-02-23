using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;
using FG_BuildingSystem;
using FG_NewBuildingSystem;


namespace FG_EnemyAI
{


    public class EnemyAI : MonoBehaviour
    {
        #region Variables

        [Header("Patrol Settings")] [SerializeField]
        private NavMeshAgent agent;

        [SerializeField] private Vector3 destination = new Vector3();
        [Header("Animations")] public Animator animator;
        [SerializeField] private AnimationClip deathAnimation;
        [Header("Enemy Stats Settings")] public float maxHealth = 100f;
        [HideInInspector] public float health;
        [SerializeField] private float damage = 1f;
        [SerializeField] private int moneyGain = 25;

        [SerializeField]
        [Tooltip("A Radius in which the enemy will detect buildings" +
                 "Set to 0 to disable detection" +
                 "Set to the same value as Collider radius for best results")]
        private float detectionRadius = 0f;



        public bool isDeath = false;
        private bool isAttacking;
        private List<Collider> hitColliders = new List<Collider>();
        private byte index;
        WaveSpawner _waveSpawner;

        #endregion

        void Start()
        {
            #region Setup

            health = maxHealth;
            animator.SetBool("Run", true);
            destination = GameObject.FindGameObjectWithTag("Castle").transform.position;
            agent.SetDestination(destination);
            _waveSpawner = FindObjectOfType<WaveSpawner>();

            #endregion Setup

        }



        private void Update()
        {
            hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, LayerMask.GetMask("Building", "Castle")).ToList();
            isAttacking = hitColliders.Count > 0;
            if (agent.isStopped && !isAttacking && !isDeath)
            {
                animator.SetBool("Run", false);
                animator.SetBool("Attack", false);
                animator.SetBool("Idle", true);
            }
            else
            {
                animator.SetBool("Run", true);
                animator.SetBool("Attack", false);
                animator.SetBool("Idle", false);
            }

            if (isAttacking && !isDeath)
            {
                animator.SetBool("Run", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Attack", true);


            }

            if (!isAttacking && !isDeath)
            {
                agent.SetDestination(destination);
            }
            else
            {
                agent.isStopped = true;
            }


            if (health <= 0)
            {
                health = 0;
                StartCoroutine(Death());
            }


        }


        private void DealDamage()
        {
            Collider target = hitColliders[0];
            agent.SetDestination(target.transform.position);
            if (target.gameObject.CompareTag("Building") && hitColliders.Count > 0)
            {
                target.GetComponentInParent<BuildingBehaviour>().TakeDamage(damage);
            }
            else
            {
                Currency.TakeDamage(damage);
            }
        }

        private IEnumerator Death()
        {
            isDeath = true;
            var o = gameObject;
            o.layer = 0;
            animator.SetBool("Death", true);
            animator.SetBool("Run", false);
            animator.SetBool("Attack", false);
            animator.SetBool("Idle", false);
            agent.isStopped = true;

            _waveSpawner.spawnedEnemies.Remove(o);
            yield return new WaitForSeconds(deathAnimation.length);
            Destroy(o);
            Currency.AddCoins(moneyGain);
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
        }
    }
}

