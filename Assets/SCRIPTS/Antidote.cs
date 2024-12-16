using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public InfectionSystem infectionSystem; 
    public float healingAmount = 10f; 

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            infectionSystem.RemoveInfection(healingAmount);

            
            Destroy(gameObject);

            
            Debug.Log("Healing item used! Infection decreased by " + healingAmount);
        }
    }
}