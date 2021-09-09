using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardBehavior : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    //Used on any object that is a Hazard for the player
    //Will disable player animation on collision
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Hazard"))
        {
            _animator.enabled = false;
        }
    }
}
