using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f; // Speed of the bullet
    private Vector2 moveDirection; // Direction of movement

    // Method to set the direction of movement
    public void SetMoveDirection(Vector2 direction)
    {
        moveDirection = direction.normalized; // Normalize the direction vector
    }

    void Update()
    {
        // Move the bullet in its direction
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a GameObject tagged as "Obstacle" (You can change the tag to fit your game)
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the bullet when it collides with an obstacle
            Destroy(gameObject);
        }
    }
}
