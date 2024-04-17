using UnityEngine;



public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemyPos;
    public float repeatRate = 2.0f;
    public int timeForSpawn;
    public float spawnRate;
    public Transform player;
    private Vector3 offset;


    void Update()
    {
        offset = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-40f, 40f));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("EnemySpawner", spawnRate, repeatRate);
            Destroy(gameObject, timeForSpawn);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void EnemySpawner()
    {
        GameObject skeleton = Instantiate(enemy, enemyPos.position + offset, enemyPos.rotation);
        skeleton.GetComponent<EnemyController>().target = player;
    }

}
