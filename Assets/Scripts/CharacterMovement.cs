using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 100f;
    public Transform orientation;
    private Vector3 moveDirection;

    float verticalInput;
    float horizontalInput;

    public bool grounded = true;
    private Rigidbody _rigidbody;
    public float jumpForce = 10f;
    public float jumpCooldown;
    public float airMultiplier;
    public bool readyToJump;

    public float playerHeight;
    public LayerMask whatIsGround;
    public float groundDrag;
  
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput();

        //checks if we are grounded
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        if (grounded)
        {
            //gives us friction drag
            _rigidbody.drag = groundDrag;
        }
        else
        {
            _rigidbody.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void MoveInput()
    {
        //gets our input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // controls ability to jump
        if (Input.GetKeyDown(KeyCode.Space) && readyToJump && grounded)
        {
            Jump();
            readyToJump = false;

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void Jump()
    {
        //reset y velocity
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
        //jump
        _rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void MovePlayer()
    {
        //sets direction based on inputs
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        //on ground
        if (grounded)
        {
            _rigidbody.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
        }
        // in air - multiply speed
        else if(!grounded)
        {
            _rigidbody.AddForce(moveDirection.normalized * moveSpeed * airMultiplier, ForceMode.Force);
        }
    }
}