using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelForwardWithRotToGoal : MonoBehaviour
{
    public float ms = 5.0f;
    public GameObject goal;
    public float rotSpeed = 2.0f;

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


        if (Vector3.Distance(lookAtGoal, transform.position) > 1)
        {
            transform.Translate(new Vector3(0, 0, ms * Time.deltaTime));
        }
    }
}
