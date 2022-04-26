using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] GameObject monster;
    [SerializeField] GameObject attract;

    GameObject[] agents; 
    // Start is called before the first frame update
    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("agent");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                Instantiate(monster, hit.point, monster.transform.rotation);
                foreach(GameObject zzz in agents)
                {
                    zzz.GetComponent<AIControl>().DetectNewObstacle(hit.point);
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                Instantiate(attract, hit.point, attract.transform.rotation);
                foreach (GameObject zzz in agents)
                {
                    zzz.GetComponent<AIControl>().GoToNewObstacle(hit.point);
                }
            }
        }
    }
}
