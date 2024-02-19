using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinSound; // Assign the coin sound effect in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (coinSound != null)
            {
                // Play the coin sound effect at the coin's position
                float volume = 30.0f;
                AudioSource.PlayClipAtPoint(coinSound, transform.position, volume);
            }

            // Assuming you have a ScoreManager script to manage the score
            ScoreManager.instance.AddScore(100);
            Destroy(gameObject);
        }
    }
}
