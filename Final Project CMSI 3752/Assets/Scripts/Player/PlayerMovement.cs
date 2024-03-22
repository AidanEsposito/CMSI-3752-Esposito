using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab; // Prefab of the bullet object
    public float fireSpeed = 10f; // Speed of the fired bullet
    public float fireRate = 0.5f; // Rate of firing (in seconds)
    public AudioClip fireSound;

    private Vector2 lastMoveDirection = Vector2.right; // Initial direction
    private float nextFireTime;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Movement
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(moveInput * moveSpeed * Time.deltaTime);

        // Shooting
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate; // Update next fire time based on fire rate
        }

        // Remembering the last move direction for shooting
        if (moveInput != Vector2.zero)
        {
            lastMoveDirection = moveInput.normalized;
        }
    }

    void Fire()
    {
        // Instantiate a new bullet object
        GameObject bulletObject = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Set the layer of the bullet to match the layer of the player
        bulletObject.layer = gameObject.layer;

        // Get the Bullet component from the bulletObject
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            // Set the direction of movement of the bullet to the last move direction of the player
            bullet.SetMoveDirection(lastMoveDirection);
        }

        if (fireSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(fireSound);
        }
    }
}
