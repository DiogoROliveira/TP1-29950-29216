using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public Transform player;
    private Transform playerTransform;

    void Awake()
    {
        playerTransform = player.transform;
    }

    void Update()
    {
        transform.position = playerTransform.position;
    }

}
