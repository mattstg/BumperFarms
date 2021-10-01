using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    const float slowThreshold = .05f;

    public float moveForce;
    public float maxSpeed;
    public float speedDampener = .3f; //% loss per second
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update

  


    //Only call during fixed update
    public void MoveInDirection(Vector2 dirVector)
    {
        if (dirVector != Vector2.zero)
        {
            dirVector.Normalize();
            rb.AddForce(new Vector3(dirVector.x, 0, dirVector.y) * moveForce);
        }
        else
        {
            Debug.Log("Hdgd");
            rb.velocity = rb.velocity - rb.velocity * speedDampener * Time.fixedDeltaTime;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 groundSpeed = new Vector2(rb.velocity.x, rb.velocity.z);


        if (groundSpeed.magnitude > maxSpeed)
        {
            Vector2 clamped = Vector2.ClampMagnitude(groundSpeed, maxSpeed);
            rb.velocity = new Vector3(clamped.x, rb.velocity.y, clamped.y);
        } 
                
    }
}
