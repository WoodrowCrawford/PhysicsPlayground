using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickerBehavior : MonoBehaviour
{
    public float force = 5.0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    Rigidbody rb;

                    if(rb = hit.transform.GetComponent<Rigidbody>())
                    {
                        LaunchIntoAir(rb);
                    }
                }

            }
        }
    }

    private void LaunchIntoAir(Rigidbody rigidbody)
    {
        //Launches the ball into the air
        rigidbody.AddForce(rigidbody.transform.up * force, ForceMode.Impulse);
        
    }
}
