using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public float fireSpeed = 10f;
    public float fireRate = 0.5f;
    public AudioClip fireSound;
    public AudioClip hitSound;
    public float invincibilityDuration = 3f;
    public int maxHitsAllowed = 3;
    public GameObject gameOverText; // Reference to the UI Text element displaying "GAME OVER"

    private Vector2 lastMoveDirection = Vector2.right;
    private float nextFireTime;
    private AudioSource audioSource;
    private bool isInvincible = false;
    private int hitCount = 0;
    private Renderer renderer2D;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        renderer2D = GetComponent<Renderer>();
        // Initially, hide the "GAME OVER" text
        gameOverText.SetActive(false);
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(moveInput * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }

        if (moveInput != Vector2.zero)
        {
            lastMoveDirection = moveInput.normalized;
        }
    }

    void Fire()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletObject.layer = gameObject.layer;
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.SetMoveDirection(lastMoveDirection);
        }

        if (fireSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(fireSound);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !isInvincible)
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
