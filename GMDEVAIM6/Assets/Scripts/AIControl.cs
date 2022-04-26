using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    GameObject[] goalLocation;
    NavMeshAgent agent;
    Animator animator;
    float speedMult;
    float detectionRadius = 30;
    float fleeRadius = 10;

    void ResetAgent()
    {
        speedMult = Random.Range(0.1f, 1.5f);
        agent.speed = 2 * speedMult;
        agent.angularSpeed = 120;
        animator.SetFloat("speedMultiplier", speedMult);
        animator.SetTrigger("isWalking");
        agent.ResetPath();
    }

    private void Start()
    {
        goalLocation = GameObject.FindGameObjectsWithTag("goal");
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(goalLocation[Random.Range(0, goalLocation.Length)].transform.position);
        animator = this.GetComponent<Animator>();
        animator.SetFloat("wOffset", Random.Range(0.1f, 1f));
        ResetAgent();

    }

    private void Update()
    {
        if (agent.remainingDistance < 2f)
        {
            ResetAgent();
            agent.SetDestination(goalLocation[Random.Range(0, goalLocation.Length)].transform.position);
        }
    }

    public void DetectNewObstacle(Vector3 location)
    {
        if (Vector3.Distance(location, this.transform.position) < detectionRadius)
        {
            Vector3 fleeDirection = (this.transform.position - location).normalized;
            Vector3 newGoal = this.transform.position + fleeDirection * fleeRadius;

            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(newGoal, path);

            if(path.status != NavMeshPathStatus.PathInvalid)
            {
                agent.SetDestination(path.corners[path.corners.Length - 1]);
                animator.SetTrigger("isRunning");
                agent.speed = 10;
                agent.angularSpeed = 500;
            }
        }
    }

    public void GoToNewObstacle(Vector3 location)
    {
        if (Vector3.Distance(location, this.transform.position) < detectionRadius)
        {
            //Vector3 fleeDirection = (this.transform.position - location).normalized;
            //Vector3 newGoal = this.transform.position + fleeDirection * fleeRadius;

            //NavMeshPath path = new NavMeshPath();
            //agent.CalculatePath(newGoal, path);

            //if (path.status != NavMeshPathStatus.PathInvalid)
            //{
            agent.SetDestination(location);
            animator.SetTrigger("isRunning");
            agent.speed = 10;
            agent.angularSpeed = 500;
            //}
        }
    }
}
