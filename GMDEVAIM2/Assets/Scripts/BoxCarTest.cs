using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCarTest : MonoBehaviour
{
    public Transform goal;
    public float speed = 0;
    public float rotSpeed = 1;

    public float acceleration = 5;
    public float decceleration = 5;

    public float minSpeed = 0;
    public float maxSpeed = 20;

    public float breakAngle = 20;

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        /*
        Vector3 lookAtGoal = new Vector3(goal.position.x,
                                        this.transform.position.y,
                                        goal.position.z);

        */
        Vector3 lookAtGoal = new Vector3(goal.position.x,
                                        goal.position.y,
                                        goal.position.z);

        Vector3 direction = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    Time.deltaTime * speed);


        //speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);

        if (Vector3.Angle(goal.forward, this.transform.forward) > breakAngle && speed > 2)
        {
            speed = Mathf.Clamp(speed - (decceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        else
        {
            speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        }

        //this.transform.Translate(0, 0, speed);
        //rb.AddForce(transform.forward * speed);

        // kinematic
         rb.MovePosition(transform.position + (transform.forward * speed));

        // rb.velocity
    }
}
