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
        if (PauseMenu.GameIsPaused) { return; }
        transform.position = playerTransform.position;
    }

}
