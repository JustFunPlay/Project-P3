﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIDinand : MobHitPoints
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Idle();
        else if (playerInSightRange && !playerInAttackRange) Hunt();
        else if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    void Idle()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkpoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkpoint;

        if (distanceToWalkPoint.magnitude < 1)
        {
            walkPointSet = false;
        }
    }

    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomX);
        if (Physics.Raycast(walkpoint, -transform.up, 2, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    void Hunt()
    {
        agent.SetDestination(player.position);
    }

    void AttackPlayer()
    {
        RaycastHit hit;
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        Physics.Raycast(transform.position, transform.forward, out hit, attackRange);
        if (hit.collider.gameObject.tag == "Player")
        {
            if (!alreadyAttacked)
            {
                StartCoroutine(Attack());
                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public virtual IEnumerator Attack()
    {
        yield return null;
    }
}
