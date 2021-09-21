using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickerBehavior : MonoBehaviour
{
    public float force = 5.0f;

    private void Update()
    {
        //Receives the input from the mouse if the player clicks the left mouse button
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
                        //Launches the selected game object in the air on clilk
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
