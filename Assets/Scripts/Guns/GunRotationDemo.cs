using UnityEngine;

namespace PixelGunsPack
{
    public class GunRotationDemo : MonoBehaviour
    {
        [Range(0, 100)]
        [SerializeField] private float rotateSpeed = 50;

        private void Update()
        {
            transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
        }
    }
}
