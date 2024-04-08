using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 200f;
    public Transform fpsCam;
    public ParticleSystem muzzleFlash;


    private float nextTimeToFire = 0f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {

        if (fpsCam.GetChild(1) == null)
        {
            return;
        }

        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            // Obter o componente Target do GameObject atingido
            Target target = hit.transform.GetComponent<Target>();

            // Verificar se o componente Target existe
            if (target != null)
            {
                target.TakeDamage(damage);
            }



        }
    }
}
