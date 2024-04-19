using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    public GameObject dronePrefab; 
    public Transform spawnPoint; 
    public float spawnInterval = 1f; 
    public float minDistanceFromPlayer = 2f;
    public float maxSpawnRadius = 5f; // Maximum distance from player to spawn drone

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnDrone();
            timer = 0f;
        }
    }

    void SpawnDrone()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player not found!");
            return;
        }

        float distanceToPlayer = Vector3.Distance(spawnPoint.position, player.transform.position);

        // Check if the player is within the desired spawn radius
        if (distanceToPlayer > maxSpawnRadius)
        {
            Debug.Log("Player is too far from the spawner. Drone cannot spawn.");
            return;
        }

        if (distanceToPlayer < minDistanceFromPlayer)
        {
            Debug.Log("Player too close to spawn point. Drone cannot spawn.");
            return;
        }

        GameObject newDrone = Instantiate(dronePrefab, spawnPoint.position, Quaternion.identity);
        newDrone.transform.SetParent(GameObject.Find("Enemies").transform);

        DroneEnemy droneEnemy = newDrone.GetComponent<DroneEnemy>();
        if (droneEnemy != null)
        {
            droneEnemy.SetDroneSpawner(this);
        }
    }

    public void RemoveDrone(DroneEnemy drone)
    {
        if (drone != null)
        {
            Destroy(drone.gameObject);
        }
    }
}
