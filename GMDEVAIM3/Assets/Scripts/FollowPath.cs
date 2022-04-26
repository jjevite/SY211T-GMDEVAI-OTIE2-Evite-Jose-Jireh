using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FollowPath : MonoBehaviour
{
    Transform goal;
    [SerializeField] float speed = 10.0f;
    float accuracy = 1.0f;
    [SerializeField] float rotSpeed = 4.0f;
    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWaypointIndex = 0;
    Graph graph;
    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        graph = wpManager.GetComponent<WaypointManager>().graph;
        currentNode = wps[0];
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (graph.getPathLength() == 0 || currentWaypointIndex == graph.getPathLength())
        {
            return;
        }

        currentNode = graph.getPathPoint(currentWaypointIndex);

        if(Vector3.Distance(graph.getPathPoint(currentWaypointIndex).transform.position,
                            transform.position) <accuracy)
        {
            currentWaypointIndex++;
        }

        if(currentWaypointIndex < graph.getPathLength())
        {
            goal = graph.getPathPoint(currentWaypointIndex).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                        Quaternion.LookRotation(direction),
                                                        Time.deltaTime * rotSpeed);
            this.transform.Translate(0, 0, speed * Time.deltaTime);

        }
    }

    public void GoToTwinMountains()
    {
        if (Vector3.Distance(wps[3].transform.position, transform.position) < 2) return;
        graph.AStar(currentNode, wps[3]);
        currentWaypointIndex = 0;
    }
    public void GoToBarracks()
    {
        if (Vector3.Distance(wps[15].transform.position, transform.position) < 2) return;
        graph.AStar(currentNode, wps[15]);
        currentWaypointIndex = 0;
    }
    public void GoToCommandCenter()
    {
        if (Vector3.Distance(wps[0].transform.position, transform.position) < 2) return;
        graph.AStar(currentNode, wps[0]);
        currentWaypointIndex = 0;
    }
    public void GoToRefinery()
    {
        if (Vector3.Distance(wps[8].transform.position, transform.position) < 2) return;
        graph.AStar(currentNode, wps[8]);
        currentWaypointIndex = 0;
    }
    public void GoToTankers()
    {
        if (Vector3.Distance(wps[10].transform.position, transform.position) < 2) return;
        graph.AStar(currentNode, wps[10]);
        currentWaypointIndex = 0;
    }
    public void GoToRadar()
    {
        if (Vector3.Distance(wps[5].transform.position, transform.position) < 2) return;
        graph.AStar(currentNode, wps[5]);
        currentWaypointIndex = 0;
    }
    public void GoToCommandPost()
    {
        if (Vector3.Distance(wps[4].transform.position, transform.position) < 2) return;
        graph.AStar(currentNode, wps[4]);
        currentWaypointIndex = 0;
    }
    public void GoToMiddle()
    {
        if (Vector3.Distance(wps[14].transform.position, transform.position) < 2) return;
        graph.AStar(currentNode, wps[14]);
        currentWaypointIndex = 0;
    }
}
