using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPetScript : MonoBehaviour
{
    public GameObject goal;
    public float ms;
    public float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 lookAtGoal = new Vector3(goal.transform.position.x,
                                       this.transform.position.y,
                                       goal.transform.position.z);


        Vector3 direction = lookAtGoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    Time.deltaTime * rotSpeed);


        if (Vector3.Distance(lookAtGoal, transform.position) > 2f)
        {
            transform.position = Vector3.Lerp(transform.position,
                                                goal.transform.position,
                                                Time.deltaTime * ms);
            Debug.Log(Vector3.Distance(this.transform.position, goal.transform.position));
        }
    }
}
