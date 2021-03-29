using System.Collections;
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
    public float moveDelay;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) StartCoroutine(Idle());
        else if (playerInSightRange && !playerInAttackRange) Hunt();
        else if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    IEnumerator Idle()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkpoint);

        Vector3 distanceToWalkPoint = transform.position - walkpoint;

        if (distanceToWalkPoint.magnitude < 1)
        {
            for (float f = 0; f < moveDelay; f+=Time.deltaTime)
            {
                yield return null;
            }
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
