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
    private Vector3 offset = new Vector3(0, 0, 0.03f);



    private void Start()
    {
        gunRotation = gun.GetComponent<GunRotationDemo>();
    }


    protected override void Interact()
    {
        gun.GetComponent<MeshCollider>().enabled = false;
        gunRotation.enabled = false;
        gunParent.transform.SetParent(camera);
        gun.transform.SetPositionAndRotation(playerHand.localPosition, Quaternion.Euler(-90, 0, 0));
        gun.transform.position = playerHand.position + offset;
    }
}
