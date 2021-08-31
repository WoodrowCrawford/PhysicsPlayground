using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    public float speed = 5.0f;
    public float jumpForce = 10.0f;
    public float gravityModifier = 1.0f;

    private CharacterController _controller;

    private Vector3 _desiredGroundVelocity;
    private Vector3 _desiredAirVelocity;
    private bool _isJumpDesired;


    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        

        //Get movement input
        _desiredGroundVelocity.x = Input.GetAxis("Horizontal");
        _desiredGroundVelocity.y = 0.0f;
        _desiredGroundVelocity.z = Input.GetAxis("Vertical");

        //Get jump input
        _isJumpDesired = Input.GetButtonDown("Jump");

        //Sets the movement magnitude
        _desiredGroundVelocity.Normalize();
        _desiredGroundVelocity *= speed;

        //Apply jump force
        if (_isJumpDesired)
        {
            _desiredAirVelocity.y = jumpForce;
            _isJumpDesired = false;
        }

        //Apply gravity
        _desiredAirVelocity += Physics.gravity * gravityModifier * Time.deltaTime;
        _desiredGroundVelocity += _desiredAirVelocity;

        //Moves
        _controller.Move((_desiredGroundVelocity + _desiredAirVelocity) * Time.deltaTime);
    }
   
}
