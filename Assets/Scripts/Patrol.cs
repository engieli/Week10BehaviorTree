using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NodeCanvas.Framework;

public class Patrol : ActionTask<NavMeshAgent>
{
    public BBParameter<Transform[]> waypoints;  // Array of waypoints to patrol
    private int currentIndex = 0;

    protected override void OnExecute()
    {
        GoToNextWaypoint();
    }

    void GoToNextWaypoint()
    {
        if (waypoints == null || waypoints.value.Length == 0) return;
        // Use the agent provided by ActionTask<T>
        NavMeshAgent navAgent = agent;
        navAgent.SetDestination(waypoints.value[currentIndex].position);
        currentIndex = (currentIndex + 1) % waypoints.value.Length;
    }

    protected override void OnUpdate()
    {
        NavMeshAgent navAgent = agent;
        if (!navAgent.pathPending && navAgent.remainingDistance < 0.5f)
        {
            GoToNextWaypoint();
        }
    }
}

