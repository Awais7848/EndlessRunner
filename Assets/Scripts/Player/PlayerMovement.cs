using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody playerRB;

    [SerializeField] float forwardSpeed;

    Vector3 positionV;

    [SerializeField] float Smoothness;


    [SerializeField] float height;
    [Header("Ground Check")]
    [SerializeField] LayerMask groundCheck;
    [SerializeField] float GroundDistance;
    [SerializeField] Transform groundCheckPosition;
    [SerializeField] float LineDistance;
    
    Animator animator;
    CapsuleCollider capsuleCollider;

    Vector3 moveVector, jumpVector;

    bool IsGrounded
    {

        get
        {
           if(Physics.Raycast(groundCheckPosition.position, -groundCheckPosition.up, GroundDistance, groundCheck))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
    }




    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space)&&IsGrounded)
        {
            Jump();
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        SwitchLanes();
        Slide();



        animator.SetFloat("Speed", playerRB.velocity.magnitude);

    }




    private void FixedUpdate()
    {

        MoveForward();

    }


    public void Slide()
    {


        if (Input.GetKeyDown(KeyCode.S))
        {
            capsuleCollider.height = 0.5f;
            capsuleCollider.center = new Vector3(0, 0.3f, 0f);
            animator.SetTrigger("Slide");
        }

    }


    public void Jump()
    {
        jumpVector.y = Mathf.Sqrt(-2.0f * Physics2D.gravity.y * height);
        playerRB.velocity += jumpVector;

        animator.SetBool("Jump", true);
        animator.SetBool("Slide", false);

    }

    public void SwitchLanes()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            positionV.x += LineDistance;

            animator.SetTrigger("Right");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            positionV.x -= LineDistance;

            animator.SetTrigger("Left");
        }


        positionV.x = Mathf.Clamp(positionV.x, -LineDistance, LineDistance);
        positionV.z = playerRB.position.z;
        positionV.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, positionV, Time.deltaTime * Smoothness);

    }


    public void MoveForward()
    {
        moveVector = transform.forward * 100f * forwardSpeed * Time.deltaTime;
        moveVector.y = playerRB.velocity.y;

        playerRB.velocity = moveVector;
    }



}
