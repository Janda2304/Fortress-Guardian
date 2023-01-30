using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    #region Movement Variables
    [SerializeField] private CharacterController CharacterController;
    
    private float playerSpeed = 0f;
    public float walkSpeed = 0f;
    public float sprintSpeed = 0f;
    private KeyCode sprintKey = KeyCode.LeftShift;
    #endregion Movement Variables
    
    #region Jump Variables
    public int  jumpHeight;
    public float gravity = -9.81f;
    Vector3 velocity;
    [SerializeField] private Transform _groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded =>Physics.CheckSphere(_groundCheck.position, groundDistance, groundMask);
    #endregion Jump Variables

   





   
    
    private void Update()
    {
        if (Input.GetKey(sprintKey))
        {
            playerSpeed = sprintSpeed;
        }
        else
        {
            playerSpeed = walkSpeed;
        }

        
        
            
        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


    }
    private void FixedUpdate()
    {
       
        

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        var direction = Vector3.zero;


        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");



        direction = transform.right * x + transform.forward * z;


        CharacterController.Move(direction * playerSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        CharacterController.Move(velocity * Time.deltaTime);



    }
}
