using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    public float detectionRange = 5f;
    public Transform leftBoundary;  // Set this to the left boundary position
    public Transform rightBoundary; // Set this to the right boundary position

    private Rigidbody2D rb;
    private bool movingRight = true; // Flag to track movement direction

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the player is within the detection range
        GameObject targetObject = GameObject.FindGameObjectWithTag("BlueSlime");
        if (targetObject != null)
        {
            Transform target = targetObject.transform;
            float distanceToTarget = Vector2.Distance(transform.position, target.position);

            if (distanceToTarget <= detectionRange)
            {
                // Move towards the player
                Vector2 direction = (target.position - transform.position).normalized;
                rb.velocity = direction * speed;
            }
            else
            {
                // Check if the enemy is at the left or right boundary
                if (transform.position.x <= leftBoundary.position.x)
                {
                    movingRight = true; // Change direction to right
                }
                else if (transform.position.x >= rightBoundary.position.x)
                {
                    movingRight = false; // Change direction to left
                }

                // Move the enemy left or right based on the current direction
                if (movingRight)
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }
            }
        }
    }
}
