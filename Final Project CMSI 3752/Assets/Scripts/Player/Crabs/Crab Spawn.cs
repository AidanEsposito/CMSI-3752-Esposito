using UnityEngine;

public class CrabSpawner : MonoBehaviour
{
    public GameObject crabPrefab; 
    public Transform spawnPoint; 
    public float spawnInterval = 1f; 
    public float minDistanceFromPlayer = 2f;
    public float maxSpawnRadius = 5f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCrab();
            timer = 0f;
        }
    }

   void SpawnCrab()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player not found!");
            return;
        }

        float distanceToPlayer = Vector3.Distance(spawnPoint.position, player.transform.position);

        if (distanceToPlayer > maxSpawnRadius)
        {
            Debug.Log("Player is too far from the spawner. Crab cannot spawn.");
            return;
        }

        if (distanceToPlayer < minDistanceFromPlayer)
        {
            Debug.Log("Player too close to spawn point. Crab cannot spawn.");
            return;
        }

        GameObject newCrab = Instantiate(crabPrefab, spawnPoint.position, Quaternion.identity);
        newCrab.transform.SetParent(GameObject.Find("Enemies").transform);

        CrabEnemy crabEnemy = newCrab.GetComponent<CrabEnemy>();
        if (crabEnemy != null)
        {
            crabEnemy.SetCrabSpawner(this);
        }
    }

    public void RemoveCrab(CrabEnemy crab )
    {
        if (crab != null)
        {
            Destroy(crab.gameObject);
        }
    }
}
