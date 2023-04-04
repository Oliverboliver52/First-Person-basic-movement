using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    public float speed;//Max speed
    float H, V; //Input
    [SerializeField] private Rigidbody rb;//RigidBody reference
    bool canJump = false;
    [SerializeField] private GameObject GroundedCheck;
    public LayerMask mask;
    public float jump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();//Gets Input
        Move();//Moves with input
        
        canJump = GroundCheck();//Checks if the player is grounded
        if (Input.GetButton("Jump") && canJump)
        {
            rb.AddForce(new Vector3(rb.velocity.x, jump, rb.velocity.z));//Adds force to jump
        }
    }
    private void FixedUpdate()
    {
        
    }
    private void GetInput()
    {
        H = Input.GetAxis("Horizontal");//Getting the horizontal axis
        V = Input.GetAxis("Vertical");//Getting the vertical axis
    }
    private void Move()
    {
        rb.velocity = transform.TransformDirection(new Vector3(H * speed, rb.velocity.y, V * speed));//transform.TransformDirection changes the Vector3 to local
    }
    private bool GroundCheck()
    {
        return Physics.CheckSphere(GroundedCheck.transform.position, 0.25f, mask);//returns true or false if the groundcheck obj is 0.25f in or off the ground
    }
}
