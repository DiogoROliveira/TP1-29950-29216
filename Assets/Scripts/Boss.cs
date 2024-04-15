using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    private PlayerHealth player;
    public GameObject skeletonPrefab;

    public float meleeAttackRange = 2f;
    public float summonAttackMinRange = 5f;
    public float summonAttackMaxRange = 10f;
    public int numberOfSkeletons = 2;

    private bool hasAttacked = false;
    bool isAttacking = false;

    void Start()
    {
        player = target.GetComponent<PlayerHealth>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        agent.SetDestination(target.position);

        if (player.health <= 0 || GetComponentInChildren<Target>().health <= 0)
        {
            agent.SetDestination(transform.position);
            return;
        }

        agent.isStopped = false;
        animator.SetBool("isAttackingM", false);
        animator.SetBool("isAttackingS", false);

        animator.SetBool("isWalking", agent.velocity.magnitude > 0.1f);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("getHit"))
        {
            agent.isStopped = true;
            animator.SetBool("isWalking", false);
            return;
        }

        if (isAttacking)
        {
            return;
        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            if (!hasAttacked)
            {
                if (IsNearPlayer(meleeAttackRange))
                {
                    hasAttacked = true;
                    animator.SetBool("isAttackingM", true);
                    isAttacking = true;
                    player.TakeDamage(25f);
                }
                else if (IsInSummonRange())
                {
                    hasAttacked = true;
                    animator.SetBool("isAttackingS", true);
                    isAttacking = true;

                    for (int i = 0; i < numberOfSkeletons; i++)
                    {
                        Vector3 randomOffset = Random.insideUnitSphere * 2f;
                        randomOffset.y = 0f;
                        Vector3 spawnPosition = transform.position + randomOffset;
                        GameObject skeleton = Instantiate(skeletonPrefab, spawnPosition, Quaternion.identity);
                        skeleton.GetComponent<NavMeshAgent>().SetDestination(target.position);
                    }
                }
            }
        }
        else
        {
            hasAttacked = false;
        }
    }



    bool IsNearPlayer(float range)
    {
        return Vector3.Distance(transform.position, target.position) <= range;
    }

    bool IsInSummonRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        return distanceToPlayer >= summonAttackMinRange && distanceToPlayer <= summonAttackMaxRange;
    }
}