using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float zMovement = 2000f;
    public float xMovement = 2000f;
    public float yMovement = 2000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move forward
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, zMovement * Time.deltaTime);
        }

        // Move backwards
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -zMovement * Time.deltaTime);
        }

        // Move left
        if (Input.GetKey("a"))
        {
            rb.AddForce(xMovement * Time.deltaTime, 0, 0);
        }

        // Move right
        if (Input.GetKey("d"))
        {
            rb.AddForce(-xMovement * Time.deltaTime, 0, 0);
        }

        // Fly Up
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, yMovement * Time.deltaTime, 0);
        }
    }
}
