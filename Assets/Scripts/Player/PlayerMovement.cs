using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody playerRB;

    [SerializeField] float forwardSpeed;

    Vector3 positionV;

   [SerializeField] float Smoothness;
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

        
    }

    private void FixedUpdate()
    {
        playerRB.velocity += transform.forward * forwardSpeed * Time.deltaTime;


    }
}
