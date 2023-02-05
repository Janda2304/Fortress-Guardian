using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    public Vector3 spawnpoint = new Vector3();
    [SerializeField] private Vector3 destination = new Vector3();
    public Animator animator;
    private bool isAttacking;
    private Collider[] hitColliders;
    //TODO: Dealing double the damage when only one enemy is attacking
    private float damage = 0.5f;
    //

    void Start()
    {
        #region Setup

        spawnpoint = GameObject.FindGameObjectWithTag("Spawnpoint").transform.position;
        transform.position = spawnpoint;
        animator.SetBool("Run", true);
        destination = GameObject.FindGameObjectWithTag("Castle").transform.position;
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
        }
        if (!isAttacking)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Attack", false);
            agent.isStopped = false;
            



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
                    hitCollider.GetComponent<BuildingBehaviour>().TakeDamage(damage);
                }
              
            }
        }
       
    }

}
