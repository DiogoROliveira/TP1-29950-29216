using UnityEngine;
using UnityEngine.AI;


public class Target : MonoBehaviour
{
    public float health = 50f;
    private Animator animator;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    public void Damage(float amount)
    {
        health -= amount;
        health = Mathf.Round(health);
        if (health <= 0f)
        {
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            GetComponentInParent<NavMeshAgent>().enabled = false;
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }

}