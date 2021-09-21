using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
   
   
    private void OnTriggerEnter(Collider other)
    {
        //If the player touches the key it destroys itself
        if(other.gameObject.CompareTag("Player"))
        {
            
            Destroy(gameObject);
        }
    }
}
