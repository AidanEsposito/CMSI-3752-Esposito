using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public CameraFollow cameraFollow;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Find the CameraFollow script in the scene
        cameraFollow = FindObjectOfType<CameraFollow>();
        if (cameraFollow == null)
        {
            Debug.LogError("CameraFollow script not found in the scene!");
        }
        else
        {
            // Set the target of the CameraFollow script to this player's transform
            cameraFollow.target = transform;
        }
    }

    private void Update()
    {
        // Player input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move the player
        Move(horizontalInput);
    }

    private void Move(float horizontalInput)
    {
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        // Update the camera position to follow the player
        if (cameraFollow != null)
        {
            // Calculate the desired camera position on the X-axis only
            Vector3 desiredPosition = new Vector3(transform.position.x, cameraFollow.transform.position.y, cameraFollow.transform.position.z);

            // Smoothly interpolate between the current camera position and the desired position
            cameraFollow.transform.position = Vector3.Lerp(cameraFollow.transform.position, desiredPosition, cameraFollow.smoothSpeed);
        }
    }
}
