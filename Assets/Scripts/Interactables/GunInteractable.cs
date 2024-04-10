using UnityEngine;

public class GunInteractable : Interactable
{
    public GameObject gun;
    public GameObject weaponHolder;

    protected override void Interact()
    {
        gun.SetActive(true);
        GunInteractable.Destroy(gameObject);
        GunSwitching.canEquip = true;
    }
}