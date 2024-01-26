using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    public TextMeshProUGUI text;
    private bool gameOver = false;

    void Update()
    {
        if (!gameOver)
        {
            time -= Time.deltaTime;
            text.text = time.ToString("F2"); 

            if (time < 0)
            {
                text.text = "Game Over";
                gameOver = true;
                Time.timeScale = 0f; 
            }
        }
    }
}
