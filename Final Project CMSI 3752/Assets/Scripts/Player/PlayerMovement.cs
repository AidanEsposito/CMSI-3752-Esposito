using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;
    public AudioClip fireSound;
    public AudioClip hitSound;
    public float invincibilityDuration = 3f;
    public int maxHitsAllowed = 3;
    public GameObject gameOverText; // Reference to the UI Text element displaying "GAME OVER"

    private float nextFireTime;
    private AudioSource audioSource;
    private bool isInvincible = false;
    private int hitCount = 0;
    private Renderer renderer2D;
    // private PowerUpManager powerUpManager;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        renderer2D = GetComponent<Renderer>();
        // Initially, hide the "GAME OVER" text
        gameOverText.SetActive(false);
        // powerUpManager = FindObjectOfType<PowerUpManager>();
    }

    void Update()
    {
        Move();
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(moveInput * moveSpeed * Time.deltaTime);
    }

    public void AimAt(Vector3 target)
    {
        Vector2 aimDirection = (target - transform.position).normalized;
        transform.up = aimDirection; // Point the player towards the target
    }

    void Fire()
    {
        // Calculate direction towards mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 fireDirection = (mousePos - transform.position).normalized;

        // Instantiate bullet and set its direction
        GameObject bulletObject = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Debug.Log("Bullet Fired");
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.SetMoveDirection(fireDirection);
        }

        if (fireSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(fireSound);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.CompareTag("GoldCoin"))
        // {
        //     // powerUpManager.ActivatePowerUp();
        //     Destroy(other.gameObject); // Destroy the gold coin when collected
        // }
        if ((other.CompareTag("Enemy") || other.CompareTag("EnemyBullets")) && !isInvincible)
        {
            hitCount++;
            if (hitCount >= maxHitsAllowed)
            {
                GameOver();
            }
            else
            {
                StartCoroutine(InvincibilityCoroutine());
            }
        }
    }

    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        float endTime = Time.time + invincibilityDuration;
        while (Time.time < endTime)
        {
            // Toggle player visibility to create flashing effect
            renderer2D.enabled = !renderer2D.enabled;
            yield return new WaitForSeconds(0.1f); // Adjust duration of each flash here
        }
        // Ensure player is visible after invincibility ends
        renderer2D.enabled = true;
        isInvincible = false;
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0;
        gameOverText.SetActive(true);
    }
}
