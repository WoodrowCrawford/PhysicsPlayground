using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorBehavior : MonoBehaviour
{
    [SerializeField]
    public GameObject Key;

    public bool isUnlocked = false;

    private void Update()
    {
        //If the key is destroyed then the locked door destroys itself
        if(!Key)
        {
            Destroy(gameObject);
        }
    }
}
