using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public InfectionSystem infectionSystem; // Reference to the InfectionSystem (health system)
    public float healingAmount = 10f; // Amount to decrease infection

    void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding is the player
        if (other.CompareTag("Player"))
        {
            // Call the RemoveInfection function in InfectionSystem to heal the player
            infectionSystem.RemoveInfection(healingAmount);

            // Optionally, destroy the healing item after it is used
            Destroy(gameObject);

            // Print message for demonstration purposes
            Debug.Log("Healing item used! Infection decreased by " + healingAmount);
        }
    }
}