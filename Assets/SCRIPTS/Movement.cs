using System.Collections;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float cameraHeight = 10f;
    public float cameraDistance = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 0f;

    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float fireCooldown = 1f;

    private CharacterController characterController;
    private Camera playerCamera;
    private bool canFire = true;

    private Vector3 velocity;
    private float initialYPosition;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = Camera.main;
        initialYPosition = transform.position.y;
    }

    void Update()
    {
        MovePlayer();
        FollowCamera();

        if (Input.GetKeyDown(KeyCode.Space) && canFire)
        {
            FireProjectile();
            StartCoroutine(FireCooldown());
        }
    }

    void MovePlayer()
    {
        float moveDirectionZ = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * moveDirectionZ;

        if (characterController.isGrounded)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        characterController.Move(move * moveSpeed * Time.deltaTime);

        float rotateDirection = Input.GetAxis("Horizontal");
        if (rotateDirection != 0)
        {
            float rotationAmount = rotateDirection * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotationAmount, 0);
        }

        characterController.Move(velocity * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, initialYPosition, transform.position.z);
    }

    void FollowCamera()
    {
        Vector3 cameraPosition = transform.position + Vector3.up * cameraHeight - transform.forward * cameraDistance;
        playerCamera.transform.position = cameraPosition;
        playerCamera.transform.LookAt(transform.position);
    }

    void FireProjectile()
    {
        if (projectilePrefab != null)
        {
            float offsetDistance = 1.5f;
            Vector3 spawnPosition = transform.position + transform.forward * offsetDistance;

            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, transform.rotation);

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = transform.forward * projectileSpeed;
            }

            projectile.AddComponent<Projectile>();
        }
    }

    IEnumerator FireCooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(fireCooldown);
        canFire = true;
    }

    public class Projectile : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(1);
                }
            }
            Destroy(gameObject);
        }
    }
}

