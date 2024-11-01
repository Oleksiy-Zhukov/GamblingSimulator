using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public Rigidbody rb;

    public GameObject cam;

    public float walkSpeed;
    public float runSpeed;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        // var forward = cam.transform.forward;
        // var right = cam.transform.right;

        // if(Input.GetKey(KeyCode.W))
        // {
        //     rb.velocity = forward * walkSpeed;
        // }

        // if(Input.GetKey(KeyCode.S))
        // {
        //     rb.velocity = -forward * walkSpeed;
        // }

        // if(Input.GetKey(KeyCode.A))
        // {
        //     rb.velocity = -right * walkSpeed;
        // }

        // if(Input.GetKey(KeyCode.D))
        // {
        //     rb.velocity = right * walkSpeed;
        // }
    }

    void FixedUpdate()
    {
        Vector3 newVelocity = Vector3.up * rb.velocity.y;
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;
        rb.velocity = newVelocity;
    }
}
