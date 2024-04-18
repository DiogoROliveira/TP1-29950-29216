using UnityEngine;

public class BlockArena : MonoBehaviour
{

    public GameObject block;
    public GameObject enemy;
    public Transform enemyPos;
    public Transform player;
    private GameObject boss;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("SpawnBoss", 1);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            block.SetActive(true);
        }
    }

    void Update()
    {
        if (boss.GetComponentInChildren<Target>().health <= 0)
        {
            Destroy(block);
        }
    }



    void SpawnBoss()
    {
        boss = Instantiate(enemy, enemyPos.position, enemyPos.rotation);
        boss.GetComponent<Boss>().target = player;
        boss.GetComponentInChildren<Target>().health = 250;
    }
}
