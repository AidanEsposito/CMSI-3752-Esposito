using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;

    public static void AddScore(int points)
    {
        score += points;
    }
}
