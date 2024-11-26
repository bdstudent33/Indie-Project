using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    public float cameraHeight = 10f; // Height at which the camera follows the player
    public float cameraDistance = 5f; // Distance behind the player for the camera

    private CharacterController characterController;
    private Camera playerCamera;

    void Start()
    {
        characterController = GetComponent<CharacterController>(); // Get the CharacterController component
        playerCamera = Camera.main; // Get the main camera
    }

    void Update()
    {
        MovePlayer();
        FollowCamera();
    }

    void MovePlayer()
    {
        // Get the input for horizontal and vertical movement (WASD or arrow keys)
        float moveDirectionX = Input.GetAxis("Horizontal"); // A/D keys for left/right movement (A = -1, D = 1)
        float moveDirectionZ = Input.GetAxis("Vertical"); // W/S keys for forward/backward movement (W = 1, S = -1)

        // Create a movement vector using the input
        Vector3 move = transform.right * moveDirectionX + transform.forward * moveDirectionZ; // Combine movement

        // Apply movement to the character
        characterController.Move(move * moveSpeed * Time.deltaTime); // Move the player
    }

    void FollowCamera()
    {
        // Update camera's position relative to the player (above and behind)
        Vector3 cameraPosition = transform.position + Vector3.up * cameraHeight - transform.forward * cameraDistance;

        // Set the camera's position
        playerCamera.transform.position = cameraPosition;

        // Make the camera look at the player
        playerCamera.transform.LookAt(transform.position);
    }
}