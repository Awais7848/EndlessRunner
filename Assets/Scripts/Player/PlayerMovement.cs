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

    [Header("GameOver References")]
    [SerializeField] GameObject camera;
    [SerializeField] GameObject particles;

    [SerializeField] AudioClip MovementClip, JumpClip;
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
        GameEvents.GameOver += GameOver;
    }

    void GameOver()
    {
        forwardSpeed = 0f;
        animator.SetTrigger("Death");
        
        camera.SetActive(true);
        particles.gameObject.SetActive(true);
        this.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {


        if (!IsGrounded)
        {

            animator.SetBool("Jump", false);
        }



        animator.SetFloat("Speed", playerRB.velocity.magnitude);

    }




    private void FixedUpdate()
    {

        MoveForward();
        SwitchLanes();
    }


   


 



     void SwitchLanes()
    {

      


        positionV.x = Mathf.Clamp(positionV.x, -LineDistance, LineDistance);
        positionV.z = playerRB.position.z;
        positionV.y = playerRB.position.y;
        playerRB.position = Vector3.Lerp(transform.position, positionV, Time.deltaTime * Smoothness);

    }
     void MoveForward()
    {
        moveVector = transform.forward * 100f * forwardSpeed * Time.deltaTime;
        moveVector.y = playerRB.velocity.y;

        playerRB.velocity = moveVector;
    }



    public void MoveLeft()
    {
      

        
            positionV.x -= LineDistance;

            animator.SetTrigger("Left");
        AudioSource.PlayClipAtPoint(MovementClip,transform.position);
       
    }
    public void MoveRight()
    {
     
            positionV.x += LineDistance;

            animator.SetTrigger("Right");

        AudioSource.PlayClipAtPoint(MovementClip, transform.position);

    }
    public void Slide()
    {



        capsuleCollider.height = 0.5f;
        capsuleCollider.center = new Vector3(0, 0.3f, 0f);
        animator.SetTrigger("Slide");
        if (!IsGrounded)
        {
            jumpVector.y = 2.0f * Physics2D.gravity.y * height;
            playerRB.velocity += jumpVector;
        }
        AudioSource.PlayClipAtPoint(JumpClip, transform.position);


    }
    public void Jump()
    {
        if (IsGrounded)
        {
            jumpVector.y = Mathf.Sqrt(-2.0f * Physics2D.gravity.y * height);
            playerRB.velocity += jumpVector;

            animator.SetBool("Jump", true);
            animator.SetBool("Slide", false);

            AudioSource.PlayClipAtPoint(JumpClip, transform.position);
        }

    }

    public void SlideEnd()
    {

        capsuleCollider.height = 2f;
        capsuleCollider.center = new Vector3(0, 1f, 0f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Debug.Log("tEST");
            animator.SetBool("Death", true);
        }
    }

}
