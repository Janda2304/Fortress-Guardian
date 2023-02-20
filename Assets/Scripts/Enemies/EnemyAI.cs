using System;
using System.Collections;
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
    [SerializeField] private AnimationClip deathAnimation;
    [Header("Other Scripts")]
    [SerializeField] private Currency _currency;

    [Header("Enemy Stats Settings")] 
    public float maxHealth = 100f;
    [HideInInspector] public float health;
    [SerializeField] private float damage = 1f;
    [SerializeField] private int moneyGain = 25;

    [SerializeField] [Tooltip("A Radius in which the enemy will detect buildings" +
                              "Set to 0 to disable detection" +
                              "Set to the same value as Collider radius for best results")] 
    private float detectionRadius = 0f;
    [Header("Others")] 
    [SerializeField] private Collider coll;

    

    private bool isIdle = false;
    public bool isDeath = false;
    private bool isAttacking;
    private Collider[] hitColliders;
    private byte index;
    WaveSpawner _waveSpawner;
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
        _waveSpawner = FindObjectOfType<WaveSpawner>();

        #endregion Setup

    }
   
    
    
    private void Update()
    {
      
        var transform1 = transform;
        isAttacking =  Physics.CheckSphere(transform1.position, detectionRadius, LayerMask.GetMask("Building", "Castle"));
        hitColliders = Physics.OverlapSphere(transform1.position, detectionRadius, LayerMask.GetMask("Building", "Castle"));
        if (isAttacking)
        {
            animator.SetBool("Attack", true);
            animator.SetBool("Run", false);
            agent.destination = hitColliders[0].transform.position;
            agent.isStopped = true;
           
        }
        
        if (!isAttacking && !isIdle)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Attack", false);
            agent.destination = destination;
            agent.isStopped = false;
        }

        

        if (Vector3.Distance(transform.position, destination) < 3f && !isAttacking)
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
            StartCoroutine(Death());

        }
    }

    private void DealDamage()
    {
        if (hitColliders.Length > 0)
        {
          
            Collider hitCollider = hitColliders[0];
            if (hitCollider.gameObject.CompareTag("Building"))
            {
                hitCollider.GetComponentInParent<BuildingBehaviour>().TakeDamage(damage);
                transform.LookAt(hitCollider.transform);
            }
            else
            {
                Currency.TakeDamage(damage);
                transform.LookAt(hitCollider.transform);
            }
         
                
                
              
        }

    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    
    private IEnumerator Death()
    {
        animator.SetBool("Death", true);
        _waveSpawner.spawnedEnemies.Remove(gameObject);
        
        gameObject.layer = 0;
        yield return new WaitForSeconds(deathAnimation.length);
        Destroy(gameObject);
        Currency.AddCoins(moneyGain);
    }
    
   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {
            isAttacking = true;
            hitColliders[0] = collision.collider;
        }
    }
}
