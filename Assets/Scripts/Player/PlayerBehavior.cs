using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public Camera playerCamera;

    [SerializeField]
    public GameObject checkPoint;

    [SerializeField]
    public PlayerBehavior player;

    public GameObject gameManagers;

    private GameManagerBehavior gameManager;
 
    private CharacterController _controller;

    [SerializeField]
    private Animator _animator;


    public float speed = 5.0f; //How fast the player will go
    public float jumpStrength = 10.0f; //How high the player can jump
    public float airControl = 1.0f;  //How much movement control the player has while in the air
    public float gravityModifier = 1.0f; //Affects the gravity in the scene

   
    public bool hasRespawned = true;
    public bool faceWithCamera = true;
    

    private bool _isJumpDesired = false;
    private bool _isGrounded = false;

    private Vector3 _desiredVelocity;
    private Vector3 _airVelocity;



    private void Awake()
    {
        //Gets all the components that the player behavior needs
        _controller = GetComponent<CharacterController>();
        player = GetComponent<PlayerBehavior>();
        gameManager = GetComponent<GameManagerBehavior>();
        gameManager = gameManagers.gameObject.GetComponent<GameManagerBehavior>();
    }

  

    //Enables the player animation if the player died
    public void Respawn()
    {
        //If the player dies then restart the game
        if(Input.GetKeyDown(KeyCode.Q))
        {
            gameManager.RestartGame();
            Debug.Log("Respawn!");
        }
        
    }

  
    private void Update()
    {
        Respawn();

        //Get movement input
        float inputForward = Input.GetAxis("Vertical");
        float inputRight = Input.GetAxis("Horizontal");

        //Get camera forward
        Vector3 cameraForward = playerCamera.transform.forward;
        cameraForward.y = 0.0f;
        cameraForward.Normalize();

        //Get camera right
        Vector3 cameraRight = playerCamera.transform.right;

        //Find the desired velocity
        _desiredVelocity = (cameraForward * inputForward) + (cameraRight * inputRight);

        //Get jump input
        _isJumpDesired = Input.GetButtonDown("Jump");

        //Set movement magnitude
        _desiredVelocity.Normalize();
        _desiredVelocity *= speed;

        //Check for ground
        _isGrounded = _controller.isGrounded;

        //Update animations
        if (faceWithCamera)
        {
            transform.forward = cameraForward;
            _animator.SetFloat("Speed", inputForward);
            _animator.SetFloat("Direction", inputRight);
        }
        else
        {
            if (_desiredVelocity != Vector3.zero)
                transform.forward = _desiredVelocity.normalized;
            _animator.SetFloat("Speed", _desiredVelocity.magnitude / speed);
        }
        _animator.SetBool("Jump", !_isGrounded);

        //Apply jump strength
        if (_isJumpDesired && _isGrounded)
        {
            _airVelocity.y = jumpStrength;
            _isJumpDesired = false;
        }

        //Stop on ground
        if (_isGrounded && _airVelocity.y < 0.0f)
        {
            _airVelocity.y = -1.0f;
        }

        //Apply gravity
        _airVelocity += Physics.gravity * gravityModifier * Time.deltaTime;

        //Add air velocity
        _desiredVelocity += _airVelocity;

        //Move
        _controller.Move(_desiredVelocity * Time.deltaTime);
    }
}