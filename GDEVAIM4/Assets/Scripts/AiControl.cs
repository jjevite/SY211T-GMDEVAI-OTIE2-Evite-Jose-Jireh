using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControl : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    private void Start()
    {
        this.agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();  
    }
}
