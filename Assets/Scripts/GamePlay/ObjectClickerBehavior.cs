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
                        PrintName(hit.transform.gameObject);
                        LaunchIntoAir(rb);
                    }
                }

            }
        }
    }
    private void PrintName(GameObject gameObject)
    {
        print(gameObject.name);
    }

    private void LaunchIntoAir(Rigidbody rigidbody)
    {
        rigidbody.AddForce(rigidbody.transform.forward * force, ForceMode.Impulse);
    }
}
