using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    CharacterController controller;
    [SerializeField]
    float speed = 12f, gravity = -9.81f, jumpHeight = 3;
    float x, z;
    float groundDistance = 0.4f;

    public LayerMask groundMask;


    Vector3 velocity;
    bool isGrounded;

    
    private void Start()
    {
        
    }
    //Pensar sobre ventajas de declarar global vs local en este caso.
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //Jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime; 

        //Volvemos a multiplicar por el tiempo porque así lo exige la física
        controller.Move(velocity * Time.deltaTime);
    }




}

