using UnityEngine;

public class Barrier : MonoBehaviour
{
    public Transform startPosition; // Assign the start position of your player in the Inspector

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reset the player's position to the start position
            collision.gameObject.GetComponent<PlayerController>().TeleportToStart();
        }
    }
}
