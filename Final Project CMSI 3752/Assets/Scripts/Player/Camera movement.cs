using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the player's Transform component
    public float smoothSpeed = 0.125f; // Smoothness of camera movement

    void LateUpdate()
    {
        if (target != null) // Ensure target is not null
        {
            // Calculate the desired position for the camera
            Vector3 desiredPosition = target.position + new Vector3(0, 0, transform.position.z);

            // Smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update the camera's position
            transform.position = smoothedPosition;
        }
    }
}
