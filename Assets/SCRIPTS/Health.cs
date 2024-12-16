using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Slider healthSlider;
    public GameOverManager gameOverManager;

    public float damagePerSecond = 15f;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

        if (gameOverManager == null)
        {
            gameOverManager = FindObjectOfType<GameOverManager>();
            if (gameOverManager == null)
            {
                Debug.LogError("GameOverManager is not found in the scene!");
            }
        }
    }

    void Update()
    {
        healthSlider.value = currentHealth;

        if (currentHealth <= 0 && !gameOverManager.gameOverScreen.activeSelf)
        {
            gameOverManager.GameOver();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        healthSlider.value = currentHealth;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(damagePerSecond * Time.deltaTime);
        }
        else if (other.CompareTag("HealthPickup"))
        {
            Heal(25f);
            Destroy(other.gameObject);
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthSlider.value = currentHealth;
    }
}