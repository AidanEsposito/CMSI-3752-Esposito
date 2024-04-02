using UnityEngine;

public class CrabSpawner : MonoBehaviour
{
    public GameObject crabPrefab; 
    public Transform spawnPoint; 
    public float spawnInterval = 1f; 

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
       
        GameObject newCrab = Instantiate(crabPrefab, spawnPoint.position, Quaternion.identity);

        CrabEnemy crabEnemy = newCrab.GetComponent<CrabEnemy>();
        if (crabEnemy != null)
        {
            crabEnemy.SetCrabSpawner(this);
        }
    }

    public void RemoveCrab(CrabEnemy crab)
    {
        if (crab != null)
        {
            Destroy(crab.gameObject);
        }
    }
}
