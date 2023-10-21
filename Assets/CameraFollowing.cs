using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform target; // Reference to the player character's Transform
    public Vector3 offset = new Vector3(0, 2, -10); // Offset to adjust camera position
    public float smoothTime = 0.3f; // Smoothing time for camera movement
    public Vector2 minPosition= new Vector2(0, 0); // Minimum camera position
    public Vector2 maxPosition= new Vector2(100, 5); // Maximum camera position

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // Calculate the target position with offset
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera to the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Clamp camera position within defined limits
        float clampedX = Mathf.Clamp(transform.position.x, minPosition.x, maxPosition.x);
        float clampedY = Mathf.Clamp(transform.position.y, minPosition.y, maxPosition.y);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        minPosition.x = transform.position.x;

    }
}
