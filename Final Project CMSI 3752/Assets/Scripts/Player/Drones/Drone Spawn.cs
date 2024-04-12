using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    public GameObject dronePrefab; 
    public Transform spawnPoint; 
    public float spawnInterval = 1f; 

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
       
        GameObject newDrone = Instantiate(dronePrefab, spawnPoint.position, Quaternion.identity);
        newDrone.gameObject.transform.SetParent(GameObject.Find("Enemies").transform);

        DroneEnemy droneEnemy = newDrone.GetComponent<DroneEnemy>();
        if (droneEnemy != null)
        {
            droneEnemy.SetDroneSpawner(this);
        }
    }

    public void RemoveDrone(DroneEnemy drone )
    {
        if (drone != null)
        {
            Destroy(drone.gameObject);
        }
    }
}
