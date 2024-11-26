using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 5f; // Speed at which the object moves towards the player
    public float detectionRange = 10f; // Distance within which the object will start moving

    void Update()
    {
        if (player != null)
        {
            // Check the distance between the object and the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Move towards the player only if the distance is less than the detection range
            if (distanceToPlayer < detectionRange)
            {
                MoveTowardsPlayer();
            }
        }
    }

    void MoveTowardsPlayer()
    {
        // Calculate the direction from the object to the player
        Vector3 direction = player.position - transform.position;

        // Normalize the direction vector to ensure consistent movement speed
        direction.Normalize();

        // Move the object towards the player
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
