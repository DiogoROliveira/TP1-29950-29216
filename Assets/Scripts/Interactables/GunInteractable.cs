using UnityEngine;

public class GunInteractable : Interactable
{
    public GameObject gun;
    public GameObject weaponHolder;
    public GunSwitching gunSwitching;

    protected override void Interact()
    {
        gun.SetActive(true);
        Destroy(gameObject);
        gunSwitching.canEquip = true;
    }
}