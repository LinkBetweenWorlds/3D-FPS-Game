using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPosition : MonoBehaviour
{
    public Transform goal;
    private NavMeshAgent agent;

    private void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(goal.position);
    }
}
