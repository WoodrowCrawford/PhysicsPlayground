using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float maxDistance = 10.0f;
    public float sensitivity = 5.0f;
    public bool invertY = false;
    public float relaxSpeed = 20.0f;

    private float currentDistance;

    private void Start()
    {
        currentDistance = maxDistance;
    }

    private void Update()
    {
        //Rotate the camera
        if (Input.GetMouseButton(1))
        {
            //Store current angles
            Vector3 angles = transform.eulerAngles;
            //Get input
            Vector2 rotation;
            rotation.x = Input.GetAxis("Mouse Y") * (invertY ? 1.0f : -1.0f);
            rotation.y = Input.GetAxis("Mouse X");
            //Look up and down by rotating around the X-axis
            angles.x += rotation.x * sensitivity;
            angles.x = Mathf.Clamp(angles.x, 0.0f, 90.0f);
            //Look left and right by rotating around the Y-axis
            angles.y += rotation.y * sensitivity;
            //Set the updated angles
            transform.eulerAngles = angles;
        }

        //Move the camera
        RaycastHit hitInfo;
        if (Physics.Raycast(target.position, -transform.forward, out hitInfo, maxDistance))
        {
            //Zoom the camera in if there is a collision
            currentDistance = hitInfo.distance;
        }
        else
        {
            //Ease the camera out to the max distance if there is no collision
            currentDistance = Mathf.MoveTowards(currentDistance, maxDistance, relaxSpeed * Time.deltaTime);
        }
        //Update the camera's position
        transform.position = target.position + (-transform.forward * currentDistance);
    }
}
