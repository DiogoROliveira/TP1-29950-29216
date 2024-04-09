using PixelGunsPack;
using UnityEngine;

public class GunInteractable : Interactable
{
    public GameObject gun;
    public new Transform camera;
    public Transform playerHand;
    public GameObject gunParent;
    public ParticleSystem muzzleFlash;
    private GunRotationDemo gunRotation;

    private Gun currentGun; // Reference to the currently equipped gun

    private void Start()
    {
        gunRotation = gun.GetComponent<GunRotationDemo>();
        currentGun = gun.GetComponent<Gun>(); // Assign the current gun reference
    }

    protected override void Interact()
    {
        gun.GetComponent<MeshCollider>().enabled = false;
        gunRotation.enabled = false;
        gunParent.transform.SetParent(camera);

        if (gunParent.CompareTag("Shotgun"))
        {
            gunParent.transform.SetLocalPositionAndRotation(new Vector3(1.22f, -0.06f, -1.64f), Quaternion.Euler(0, 0, 0));
        }
        else if (gunParent.CompareTag("Pistol"))
        {
            gunParent.transform.SetLocalPositionAndRotation(new Vector3(0.41f, -0.34f, 0.48f), Quaternion.Euler(0, 0, 0));
        }

        // Update the isEquipped flag for the current gun
        currentGun.isEquipped = true;

        // Disable isEquipped flag for other guns
        foreach (var otherGun in FindObjectsOfType<Gun>())
        {
            if (otherGun != currentGun)
            {
                otherGun.isEquipped = false;
            }
        }
    }
}