using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    public float detectionRange = 5f;
    public Transform target; // Assign the player's transform to this variable

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (target != null)
        {
            float distanceToTarget = Vector2.Distance(transform.position, target.position);

            if (distanceToTarget <= detectionRange)
            {
                Vector2 direction = (target.position - transform.position).normalized;
                rb.velocity = direction * speed;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}
