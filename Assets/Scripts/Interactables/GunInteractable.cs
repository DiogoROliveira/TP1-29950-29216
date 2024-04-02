using PixelGunsPack;
using UnityEngine;
using UnityEngine.UI;

public class GunInteractable : Interactable
{
    public GameObject gun;
    public Transform playerHand;

    private GunRotationDemo gunRotation;



    private void Start()
    {
        gunRotation = gun.GetComponent<GunRotationDemo>();
    }


    protected override void Interact()
    {
        gunRotation.enabled = false;
        gun.transform.SetParent(playerHand);
        gun.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.Euler(-90, 0, 0));
    }
}
