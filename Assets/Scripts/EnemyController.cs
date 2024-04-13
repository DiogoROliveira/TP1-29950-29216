using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    private readonly float offset = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponentInChildren<Target>().health <= 0)
        {
            return;
        }

        agent.isStopped = false;
        animator.SetBool("isAttacking", false);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("getHit"))
        {
            agent.isStopped = true;
            animator.SetBool("isMoving", false);
            return;
        }

        agent.SetDestination(target.position);

        if (agent.remainingDistance <= agent.stoppingDistance + offset)
        {
            agent.isStopped = true;
            animator.SetBool("isAttacking", true);
        }

        if (agent.speed > 0.1f)
        {
            animator.SetBool("isMoving", true);
        }
        else if (agent.speed <= 0.1f)
            animator.SetBool("isMoving", false);
    }

    public void DamagePlayer()
    {
        target.GetComponent<PlayerHealth>().TakeDamage(10f);
    }

}
