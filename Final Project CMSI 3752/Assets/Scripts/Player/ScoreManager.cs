using UnityEngine;
using UnityEngine.Tilemaps;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public delegate void ScoreChangedDelegate(int newScore);
    public event ScoreChangedDelegate OnScoreChanged;

    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("ScoreManager");
                    instance = obj.AddComponent<ScoreManager>();
                }
            }
            return instance;
        }
    }

    public int score = 0;
    public Tilemap Tilemap_breakable_walls;

    public void AddScore(int points)
    {
        score += points;
        OnScoreChanged?.Invoke(score);

        if (score >= 10)
        {
            DestroyTilemap();
            Debug.Log("Wall Destroyed");
        }
    }

    private void DestroyTilemap()
    {
        if (Tilemap_breakable_walls != null)
        {
            Destroy(Tilemap_breakable_walls.gameObject);
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
