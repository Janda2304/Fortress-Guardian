using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FG_BuildingSystem;

public class EnemyAI : MonoBehaviour
{
    #region Variables
    [Header("Patrol Settings")]
    [SerializeField] private NavMeshAgent agent;
    public Vector3 spawnpoint = new Vector3();
    [SerializeField] private Vector3 destination = new Vector3();
    [Header("Animations")]
    public Animator animator;
    [Header("Other Scripts")]
    [SerializeField] private Currency _currency;

    [Header("Enemy Stats Settings")] 
    public float maxHealth = 100f;
    [HideInInspector] public float health;
    [SerializeField] private float damage = 1f;
    [SerializeField] private int moneyGain = 25;
    

    

    private bool isIdle = false;
    private bool isAttacking;
    private Collider[] hitColliders;
    private byte index;
    #endregion

    void Start()
    {
        #region Setup

        spawnpoint = GameObject.FindGameObjectWithTag("Spawnpoint").transform.position;
        health = maxHealth;
        transform.position = spawnpoint;
        animator.SetBool("Run", true);
        destination = GameObject.FindGameObjectWithTag("Castle").transform.position;
        _currency = GameObject.FindGameObjectWithTag("GameController").GetComponent<Currency>();
        agent.SetDestination(destination);

        #endregion Setup

    }
   
    
    
    private void Update()
    {
        var transform1 = transform;
        isAttacking =  Physics.CheckBox(transform1.position, transform1.localScale, Quaternion.identity, LayerMask.GetMask("Building", "Castle"));
        hitColliders = Physics.OverlapBox(transform1.position, transform1.localScale, Quaternion.identity, LayerMask.GetMask("Building", "Castle"));
        if (isAttacking)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Attack", true);
            agent.isStopped = true;
            agent.destination = hitColliders[0].transform.position;
           
        }
        
        if (!isAttacking && !isIdle)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Attack", false);
            agent.isStopped = false;
        }

        

        if (Vector3.Distance(transform.position, destination) < 1f && !isAttacking)
        {
            agent.isStopped = true;
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
            isIdle = true;
        }
           
        
        

    }

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            _currency.AddCoins(moneyGain);
        }
    }

    void DealDamage()
    {
        if (hitColliders.Length > 0)
        {
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("Building"))
                {
                    hitCollider.GetComponentInParent<BuildingBehaviour>().TakeDamage(damage);
                   
                    transform.LookAt(hitCollider.transform);
                }
                else if (hitCollider.gameObject.CompareTag("Castle"))
                {
                    _currency.health -= damage;
                }
              
            }
        }
       
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;
    }

   
}
