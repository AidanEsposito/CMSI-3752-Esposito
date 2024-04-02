using UnityEngine;

public class CrabTilesetSpawner : MonoBehaviour
{
    public GameObject crabPrefab;
    public Vector2Int tilesetGridSize;
    public Vector2 tileSize;

    void Start()
    {
        SpawnCrabsWithinTileset();
    }

    void SpawnCrabsWithinTileset()
    {
        for (int x = 0; x < tilesetGridSize.x; x++)
        {
            for (int y = 0; y < tilesetGridSize.y; y++)
            {
                Vector2 spawnPosition = CalculateSpawnPosition(x, y);
                Instantiate(crabPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    Vector2 CalculateSpawnPosition(int x, int y)
    {
        float randomX = transform.position.x + x * tileSize.x + Random.Range(0f, tileSize.x);
        float randomY = transform.position.y + y * tileSize.y + Random.Range(0f, tileSize.y);
        return new Vector2(randomX, randomY);
    }
}
