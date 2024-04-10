using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    // Gun stats
    public int damage;
    public float range, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    int bulletsShot, bulletsLeft;

    // References
    public Transform fpsCam;
    public ParticleSystem muzzleFlash;
    public LayerMask Enemy;

    // bools
    public bool isEquipped = false;
    bool shooting, readyToShoot, reloading;

    // Graphics
    public CamShake camShake;
    public float camShakeMagnitude, camShakeDuration;
    public TextMeshProUGUI text;



    void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();

        //Reload automatically
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0)
        {
            Reload();
        }

        if (magazineSize == 0)
        {
            text.SetText("0/0");
            return;
        }


        //SetText
        text.SetText(bulletsLeft + " / " + magazineSize);


        if (reloading)
        {
            text.SetText("Reloading...");
        }
    }

    void MyInput()
    {
        shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        if (magazineSize == 0 && shooting && readyToShoot) { Shoot(); }

        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }


    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }


    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

    public void UpdateUI(TextMeshProUGUI text)
    {
        text.SetText(bulletsLeft + " / " + magazineSize);
    }

    void Shoot()
    {

        readyToShoot = false;


        muzzleFlash.Play();

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);


        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, direction, out hit, range, Enemy))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.transform.GetComponent<Target>().TakeDamage(damage);
                Debug.Log("Damage: " + damage);
                Debug.Log("Health: " + hit.transform.GetComponent<Target>().health);
            }
        }

        camShake.Shake(camShakeDuration, camShakeMagnitude);

        bulletsLeft--;

        Invoke("ResetShot", timeBetweenShots);

    }


    private void ResetShot()
    {
        readyToShoot = true;
    }

}

