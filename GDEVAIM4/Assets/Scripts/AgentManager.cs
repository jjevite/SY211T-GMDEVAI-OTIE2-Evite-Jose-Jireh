using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    GameObject[] agents;
    public GameObject player;

    private void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("AI");

    }

    private void Update()
    {
        /*
        foreach (GameObject ai in agents)
        {
            ai.GetComponent<AiControl>().agent.SetDestination(player.transform.position);
        }
        */
       
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (GameObject ai in agents)
            {
                ai.GetComponent<AiControl>().agent.SetDestination(player.transform.position);
            }
        }
        

        /*
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
            {
                foreach(GameObject ai in agents)
                {
                    ai.GetComponent<AiControl>().agent.SetDestination(player.transform.position);
                }    
            }
        }
        */
    }
}
