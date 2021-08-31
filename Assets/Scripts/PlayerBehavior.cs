using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    public float speed = 5.0f;
    public float jumpForce = 10.0f;
    public float airControl = 1.0f;
    public float gravityModifier = 1.0f;

    public Camera playerCamera;

    private CharacterController _controller;

    private Vector3 _desiredGroundVelocity;
    private Vector3 _desiredAirVelocity;
    private bool _isJumpDesired = false;
    public  bool _isGrounded = false;


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

        //Get camera normal
        Vector3 cameraForward = playerCamera.transform.forward;

        cameraForward.y = 0.0f;
        cameraForward.Normalize();
        //Get camera right
        Vector3 cameraRight = playerCamera.transform.right;

        _desiredGroundVelocity = (_desiredGroundVelocity.x * cameraRight + _desiredGroundVelocity.z * cameraForward);

        //Get jump input
        _isJumpDesired = Input.GetButtonDown("Jump");

        //Sets the movement magnitude
        _desiredGroundVelocity.Normalize();
        _desiredGroundVelocity *= speed;

    }

    private void FixedUpdate()
    {

       
        //Check for ground
        _isGrounded = _controller.isGrounded;

        //Apply jump force
        if (_isJumpDesired && _controller.isGrounded)
        {
            _desiredAirVelocity.y = jumpForce;
            _isJumpDesired = false;
        }

        //stop on ground
        if (_isGrounded && _desiredAirVelocity.y < 0.0f)
        {
            _desiredAirVelocity.y = -0.1f;
        }

        //Apply gravity
        _desiredAirVelocity += Physics.gravity * gravityModifier * Time.fixedDeltaTime;

        _desiredGroundVelocity += _desiredAirVelocity;

        

        //Moves
        _controller.Move((_desiredGroundVelocity + _desiredAirVelocity) * Time.fixedDeltaTime);

       
    }
   
}
