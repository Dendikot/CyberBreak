using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float GravityMultiplier = 2f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;
    public bool isGrounded = false;
    public bool isClimbing = false;
    public LayerMask ground;
    public Transform wallCheck;

    private Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        isClimbing = Physics.CheckSphere(wallCheck.position, groundDistance, ground);

        if (isClimbing && Input.GetKey(KeyCode.W))
        {
            WallClimb();
        }
        else
        {
            Movement();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            transform.position = new Vector3(0f, 80f, 0f);
            velocity.y = 0;
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(wallCheck.position, groundDistance);
    }

    public void SetPos()
    {
        transform.position = new Vector3(0,80,0);
    }

    private void Movement()
    {
        isGrounded = Physics.CheckSphere(
                              groundCheck.position, groundDistance, ground);


        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

            GameManager.JumpFactor += 0.005f;
        }

        velocity.y += gravity * Time.deltaTime * GravityMultiplier;

        controller.Move(velocity * Time.deltaTime);
    }

    private void  WallClimb()
    {
        velocity.y = 0;
        Vector3 move = transform.up * Input.GetAxis("Vertical");
        controller.Move(move * speed * Time.deltaTime);
    }

}
