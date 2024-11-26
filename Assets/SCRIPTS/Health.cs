using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import UI namespace for the slider

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f;  // Maximum health
    public float currentHealth;     // Current health
    public Slider healthSlider;     // Reference to the slider UI element

    void Start()
    {
        // Initialize the current health to max health at the start
        currentHealth = maxHealth;

        // Set the slider's max value and current value
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    void Update()
    {

        // Update the slider value to reflect current health
        healthSlider.value = currentHealth;

        // You can add logic here for health reaching 0 (e.g., player death)
        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead!");
        }
    }

    // Function to take damage
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;  // Prevent health from going below 0
        }

        // Update slider after taking damage
        healthSlider.value = currentHealth;
    }

    // Function to heal the player
    public void Heal(float healingAmount)
    {
        currentHealth += healingAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;  // Prevent health from exceeding maxHealth
        }

        // Update slider after healing
        healthSlider.value = currentHealth;
    }
}