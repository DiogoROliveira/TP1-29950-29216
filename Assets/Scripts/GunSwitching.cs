using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GunSwitching : MonoBehaviour
{
    public int selectedGun = 0;
    public TextMeshProUGUI bulletsText;

    public bool canEquip = false;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {

        int previousSelectedGun = selectedGun;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedGun >= transform.childCount - 1)
                selectedGun = 0;
            else
                selectedGun++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedGun <= 0)
                selectedGun = transform.childCount - 1;
            else
                selectedGun--;
        }

        if (previousSelectedGun != selectedGun)
        {
            SelectWeapon();
        }
    }


    void SelectWeapon()
    {
        bulletsText.enabled = true;

        int i = 0;
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
            if (!canEquip)
            {
                if (weapon.CompareTag("Melee"))
                {
                    weapon.gameObject.SetActive(true);
                    bulletsText.enabled = false;
                }
                break;
            }

            if (i == selectedGun)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }

    }

}
