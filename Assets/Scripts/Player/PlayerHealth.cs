using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public float healthRegenRate = 2f; // Health regeneration per second
    public float regenInterval = 3f;   // Time interval between each regeneration tick
    public float chipSpeed = 2f;


    public Image frontHealthBar;
    public Image backHealthBar;

    private Coroutine regenCoroutine;
    private float lerpTimer;

    void Awake()
    {
        lerpTimer = 0f;
        frontHealthBar.fillAmount = 1f;
        backHealthBar.fillAmount = 1f;
        health = maxHealth;
    }

    private void Start()
    {
        regenCoroutine = StartCoroutine(RegenerateHealth());
    }

    private void Update()
    {
        health = Mathf.Clamp(health, 0f, maxHealth);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete *= percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete *= percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        lerpTimer = 0f;
    }

    private IEnumerator RegenerateHealth()
    {
        while (true)
        {

            yield return new WaitForSeconds(regenInterval);

            // Gradually regenerate health until it reaches maxHealth
            while (health < maxHealth)
            {
                lerpTimer = 0f;
                health += healthRegenRate * Time.deltaTime * 7.5f;
                UpdateHealthUI();
                yield return null;
            }
        }
    }

    // Method to stop health regeneration coroutine
    public void StopHealthRegeneration()
    {
        if (regenCoroutine != null)
        {
            StopCoroutine(regenCoroutine);
        }
    }
}