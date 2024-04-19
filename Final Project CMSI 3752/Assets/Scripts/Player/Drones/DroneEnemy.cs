    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class DroneEnemy : MonoBehaviour
    {
        public GameObject bulletPrefab; // Reference to the bullet prefab
        public float moveSpeed = 3f;
        public float minDistanceFromPlayer = 5f;
        public float fireInterval = 3f; // Interval between each bullet fire
        private DroneSpawner droneSpawner;

        private Transform player;

        public void SetDroneSpawner(DroneSpawner spawner)
        {
            droneSpawner = spawner;
        }

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            StartCoroutine(FireRoutine()); // Start firing routine
        }

        void Update()
        {
            // Calculate direction towards the player
            Vector2 moveDirection = player.position - transform.position;

            // If the distance to the player is less than the minimum distance, move away from the player
            if (moveDirection.magnitude < minDistanceFromPlayer)
            {
                moveDirection *= -1f; // Move away from the player
            }

            // Normalize the direction to maintain consistent movement speed
            moveDirection.Normalize();

            // Move the enemy towards the calculated direction
            transform.position += (Vector3)moveDirection * moveSpeed * Time.deltaTime;
        }

        IEnumerator FireRoutine()
        {
            while (true)
            {
                // Calculate direction towards the player
                Vector2 directionToPlayer = (player.position - transform.position).normalized;

                // Instantiate a bullet
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.SetActive(true);
                // Set bullet's direction towards the player
                bullet.GetComponent<Bullet>().SetMoveDirection(directionToPlayer);

                // Wait for the specified interval before firing again
                yield return new WaitForSeconds(fireInterval);
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PlayerBullets"))
            {
                // Destroy the enemy when hit by a bullet
                Destroy(gameObject);
            }
        }

    }
