using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jump;
    float moveVelocity;
    private Vector2 startPosition;
    public AudioClip jumpSound;
    AudioSource audioSource;

    // Grounded Vars
    bool isGrounded = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        startPosition = GetComponent<Transform>().position;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
        
        audioSource = gameObject.AddComponent<AudioSource>();
        }
    audioSource.clip = jumpSound;
    }

    void Update()
    {
    
    // Jumping
    if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W)) && isGrounded)
    {
        if (jumpSound != null)
        {
            audioSource.volume = 1.0f; // Set the volume level
            audioSource.Play();
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
        isGrounded = false;
    }

    moveVelocity = 0;

    // Left Right Movement
    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
    {
        moveVelocity = -speed;
    }
    if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
    {
        moveVelocity = speed;
    }

    // Apply horizontal movement
    GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }



    public void TeleportToStart()
    {
        rb.velocity = Vector2.zero;
        GetComponent<Transform>().position = startPosition;
    }

    // Check if Grounded
    void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f) // Check if the collision is from below (ground)
            {
                isGrounded = true;
            }
        }
    }
}
