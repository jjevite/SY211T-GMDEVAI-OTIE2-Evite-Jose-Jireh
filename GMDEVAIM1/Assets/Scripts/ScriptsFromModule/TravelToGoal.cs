using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelToGoal : MonoBehaviour
{
    public GameObject goal;
    public float ms = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(goal.transform);
        Vector3 direction = goal.transform.position - this.transform.position;
        if(direction.magnitude > 1)
        {
            transform.Translate(direction.normalized * ms * Time.deltaTime, Space.World);
        }
        
    }
}
