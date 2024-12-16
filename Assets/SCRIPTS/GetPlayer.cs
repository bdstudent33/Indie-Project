using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float detectionRange = 10f;

    private float initialYPosition;
    private Camera mainCamera;

    void Start()
    {
        initialYPosition = transform.position.y;
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer < detectionRange)
            {
                MoveTowardsPlayer();
            }
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0;
        direction.Normalize();

        transform.position += direction * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, initialYPosition, transform.position.z);
        FaceCamera();
    }

    void FaceCamera()
    {
        if (mainCamera != null)
        {
            Vector3 directionToCamera = mainCamera.transform.position - transform.position;
            directionToCamera.y = 0;
            transform.rotation = Quaternion.LookRotation(directionToCamera);
        }
    }
}
