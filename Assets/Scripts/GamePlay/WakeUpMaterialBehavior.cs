using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]

public class WakeUpMaterialBehavior : MonoBehaviour
{
    public Material awakeMaterial = null;
    public Material asleepMaterial = null;

    private Rigidbody _rigidbody = null;
    private MeshRenderer _renderer = null;

    private bool _wasAsleep = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        //Set material to asleep if rigidbody is asleep
        if (_wasAsleep && _rigidbody.IsSleeping() && asleepMaterial)
        {
            _wasAsleep = false;
            _renderer.material = asleepMaterial;
        }

        //Set material to awake if rigidbody is awake
        else if (!_wasAsleep && !_rigidbody.IsSleeping() && awakeMaterial)
        {
            _wasAsleep = true;
            _renderer.material = awakeMaterial;
        }
    }
}
