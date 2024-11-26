using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import UI namespace for the slider

public class InfectionSystem : MonoBehaviour
{
    public float maxInfection = 100f;  // Maximum infection level
    public float currentInfection;     // Current infection level
    public Slider infectionSlider;     // Reference to the slider UI element

    void Start()
    {
        // Initialize the current infection level to 0 (or starting value)
        currentInfection = 0f;

        // Set the slider's max value and current value
        infectionSlider.maxValue = maxInfection;
        infectionSlider.value = currentInfection;
    }

    void Update()
    {
        // For demonstration, increase infection over time (you can replace this with actual infection logic)
        if (currentInfection < maxInfection)
        {
            currentInfection += Time.deltaTime * 2; // Increase infection over time (adjust speed as needed)
        }

        // Update the slider value to reflect current infection
        infectionSlider.value = currentInfection;

        // You can add logic here for infection reaching max (e.g., game over)
        if (currentInfection >= maxInfection)
        {
            Debug.Log("Player is fully infected!");
        }
    }
    // Function to decrease infection (e.g., player gets treated or heals)
    public void RemoveInfection(float healingAmount)
    {
        currentInfection -= healingAmount;
        if (currentInfection < 0)
        {
            currentInfection = 0;  // Prevent infection from going below 0
        }

        // Update slider after removing infection
        infectionSlider.value = currentInfection;
    }
}
