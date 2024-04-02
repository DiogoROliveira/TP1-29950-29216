using UnityEngine;

public class GunPositionController : MonoBehaviour
{
    public Transform cameraTransform;
    public Vector3 offset;

    void Update()
    {
        // Set gun position to be aligned with the camera position plus offset
        transform.position = cameraTransform.position + offset;
    }
}

