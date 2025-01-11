using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody playerRB;

    [SerializeField] float forwardSpeed;

    Vector3 positionV;

    [SerializeField] float Smoothness;

    [SerializeField]Animator animator;

    [SerializeField] float height;

    [SerializeField] LayerMask groundCheck;
    [SerializeField] float GroundDistance;
    [SerializeField] Transform groundCheckPosition;
    [SerializeField] CapsuleCollider capsuleCollider;
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
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.D))
        {
            positionV.x += 2;

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            positionV.x -= 2;
        }


        positionV.x = Mathf.Clamp(positionV.x, -2, 2);
        positionV.z = playerRB.position.z;
        positionV.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position,positionV,Time.deltaTime*Smoothness);
        animator.SetFloat("Speed", playerRB.velocity.magnitude);
        if (Input.GetKeyDown(KeyCode.Space)&&IsGrounded)
        {
            Jump();
        }
        else
        {
            animator.SetBool("Jump", false);
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            capsuleCollider.height = 0.5f;
            capsuleCollider.center= new Vector3(0,0.3f,0f);
            animator.SetBool("Slide", true);
        }

     

        Debug.Log("Is Grounded : " + IsGrounded);
    }


    


    private void FixedUpdate()
    {
        playerRB.velocity += transform.forward * forwardSpeed * Time.deltaTime;


    }

   

    public void Jump()
    {
        playerRB.velocity += new Vector3(0, Mathf.Sqrt(-2.0f * Physics2D.gravity.y * height),0);
        animator.SetBool("Jump", true);
        animator.SetBool("Slide", false);

    }


}
