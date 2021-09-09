using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncherBehavior : MonoBehaviour
{
    public Transform target;
    public Rigidbody projectile;

    public float travelTime;

    private Vector3 _displacement = new Vector3();
    private Vector3 _acceleration = new Vector3();
    private float _time = 0.0f;
    private Vector3 _initialVelocity = new Vector3();
    private Vector3 _finalVelocity = new Vector3();

    public void LaunchProjectile()
    {
        _displacement = transform.position - target.position;
        _acceleration = Physics.gravity;
        _time = travelTime;
        _initialVelocity = FindInitialVelocity(_displacement, _acceleration, _time);
        _finalVelocity = FindFinalVelocity(_initialVelocity, _acceleration, _time);

      Rigidbody projectileInstance = Instantiate(projectile, transform.position, transform.rotation);
        projectileInstance.AddForce(_initialVelocity, ForceMode.VelocityChange);
       
    }

    private Vector3 FindFinalVelocity(Vector3 initialVelocity, Vector3 acceleration, float time)
    {
        //v = v0 + at
        Vector3 finalVelocity = initialVelocity + acceleration * time;

        return finalVelocity;

    }

    private Vector3 FindDisplacement(Vector3 initialVelocity, Vector3 acceleration, float time)
    {
        
        Vector3 displacement = initialVelocity * time + (1 / 2) * acceleration * time * time;
        return displacement;
    }

    private Vector3 FindInitialVelocity(Vector3 displacment, Vector3 acceleration, float time)
    {
        //deltaX = v0 * t + (1/2)*a*t^2
        //deltaX - (1/2)*a*t^2 = v0*t
        //deltaX/t - (1/2)*a*t = v0
        //v0 = deltaX/t - (1/2)*a*t
        Vector3 initialVelocity = displacment - (1 / 2) * acceleration * time;

        return initialVelocity;
    }

   
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            LaunchProjectile();
        }
    }

}
