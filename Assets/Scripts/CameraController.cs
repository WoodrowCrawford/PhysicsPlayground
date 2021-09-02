using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float maxDistance = 10.0f;
    public float sensitivity = 100.0f;
    public bool invertY = false;

    private float currentDistance;

    private void Start()
    {
        currentDistance = maxDistance;
    }

    private void Update()
    {
        //Rotate the camera
        if(Input.GetMouseButton(1))
        {
            //Store angles
            Vector3 angles = transform.eulerAngles;
            Vector2 rotation;

            //Gets the inputs
            rotation.x = Input.GetAxis("Mouse Y") * (invertY ? 1.0f : -1.0f);
            rotation.y = Input.GetAxis("Mouse X");

            //Look up and down by rotating around the x-axis
            angles.x = Mathf.Clamp(angles.x + rotation.x * sensitivity * Time.deltaTime, 0.0f, 70.0f);

            //look left and right by rotating around the Y axis
            angles.y += rotation.y * sensitivity * Time.deltaTime;

            //set the angles
            transform.eulerAngles = angles;

        }


        //Move the camera
        RaycastHit hitInfo;
        if (Physics.Raycast(target.position, -transform.forward, out hitInfo, maxDistance))
        {
            currentDistance = hitInfo.distance;
        }
        else
        {
            currentDistance = Mathf.MoveTowards(currentDistance, maxDistance, Time.deltaTime);
        }
        transform.position = target.position + (-transform.forward * currentDistance);
        
    }
}
