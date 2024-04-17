using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    private Animator animator;
    private readonly float offset = 1.5f;
    public float attackRange = 2f;

    bool hasAttacked = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

        if (target.GetComponent<PlayerHealth>().health <= 0 || GetComponentInChildren<Target>().health <= 0)
        {
            agent.SetDestination(transform.position);
            return;
        }

        agent.isStopped = false;
        animator.SetBool("isAttacking", false);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("getHit"))
        {
            agent.isStopped = true;
            animator.SetBool("isWalking", false);
            return;
        }


        if (agent.remainingDistance <= agent.stoppingDistance + offset)
        {
            agent.isStopped = true;

            if (IsNearTarget() && !hasAttacked)
            {
                hasAttacked = true;
                animator.SetBool("isAttacking", true);
                target.GetComponent<PlayerHealth>().TakeDamage(10f);
            }
        }
        else
        {
            hasAttacked = false;
        }


        if (agent.speed > 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else if (agent.speed <= 0.1f)
            animator.SetBool("isWalking", false);
    }


    bool IsNearTarget()
    {
        return Vector3.Distance(transform.position, target.position) <= attackRange;
    }
}
