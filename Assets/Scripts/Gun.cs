using UnityEngine;
using TMPro;

/*public class Gun : MonoBehaviour
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
}*/

/*public class Gun : MonoBehaviour
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

    // Audio
    private AudioSource audioSource;

    // Sound effect de recarga
    public AudioClip reloadSound;

    void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
        //audioSource = GetComponent<AudioSource>(); // Inicializa o componente de áudio
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

        // Reproduz o som de recarga
        if (audioSource != null && reloadSound != null)
        {
            audioSource.PlayOneShot(reloadSound);
        }
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

        // Reproduz o som do disparo apenas quando o jogador dispara a arma e o jogo não está pausado
        if (!PauseMenu.GameIsPaused)
            audioSource.Play();

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

    // Método para pausar a reprodução do som
    public void PauseSound()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    //Método para retomar a reprodução do som
    public void ResumeSound()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.UnPause();
        }
    }
}*/

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

    //Audio
    public AudioSource shotgunShootSound;
    public AudioSource shotgunReloadSound;

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

        // Reproduz o som de recarga da shotgun
        shotgunReloadSound.Play();
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

        // Reproduz o som de disparo da shotgun
        if (shotgunShootSound != null && !PauseMenu.GameIsPaused)
        {
            shotgunShootSound.Play();
        }

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
                hit.transform.GetComponent<Target>().Damage(damage);
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

    public void PauseSound()
    {
        if (shotgunShootSound != null && shotgunShootSound.isPlaying)
        {
            shotgunShootSound.Pause();
        }

        if (shotgunReloadSound != null && shotgunReloadSound.isPlaying)
        {
            shotgunReloadSound.Pause();
        }
    }

    public void ResumeSound()
    {
        if (shotgunShootSound != null && !shotgunShootSound.isPlaying)
        {
            shotgunShootSound.UnPause();
        }

        if (shotgunReloadSound != null && !shotgunReloadSound.isPlaying)
        {
            shotgunReloadSound.UnPause();
        }
    }

}