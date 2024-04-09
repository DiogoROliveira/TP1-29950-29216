using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range, spread, reloadTime;
    public int magazineSize, bulletsPerShot, bulletsInMagazine;

    public Transform fpsCam;
    public ParticleSystem muzzleFlash;
    public bool isEquipped = false;


    // Update is called once per frame
    void Update()
    {
        if (isEquipped && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // Obter o componente Target do GameObject atingido
            Target target = hit.transform.GetComponent<Target>();

            // Verificar se o componente Target existe
            if (target != null)
            {
                target.TakeDamage(damage);
                Debug.Log("Damage: " + damage);
                Debug.Log("Health: " + target.health);

            }
        }
    }

}

