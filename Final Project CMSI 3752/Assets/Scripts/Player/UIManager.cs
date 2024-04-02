using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;

    void Update()
    {
        // Update score text
        scoreText.text = "Score: " + ScoreManager.score;
    }
}