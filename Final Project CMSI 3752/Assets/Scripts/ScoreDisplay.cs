using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;

    private void Start()
    {
        // Ensure the scoreText variable is assigned
        if (scoreText == null)
        {
            Debug.LogError("Score Text not assigned in inspector!");
            return;
        }

        // Subscribe to the score update event
        ScoreManager.Instance.OnScoreChanged += UpdateScoreText;

        // Initialize the score text
        UpdateScoreText(ScoreManager.Instance.score);
    }

    private void UpdateScoreText(int newScore)
    {
        // Update the text of the Text object with the current score
        scoreText.text = "Score: " + newScore.ToString();
    }

    private void OnDestroy()
    {
        // Unsubscribe from the score update event
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.OnScoreChanged -= UpdateScoreText;
        }
    }
}
