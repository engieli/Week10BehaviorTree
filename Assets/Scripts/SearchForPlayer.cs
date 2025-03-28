using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NodeCanvas.Framework;

public class SearchForPlayer : ActionTask<NavMeshAgent>
{
    public BBParameter<Vector3> lastKnownPosition;  // Player's last known position

    protected override void OnExecute()
    {
        NavMeshAgent navAgent = agent;
        navAgent.SetDestination(lastKnownPosition.value);
        StartCoroutine(SearchRoutine());
    }

    IEnumerator SearchRoutine()
    {
        float searchTime = 5f;
        float elapsedTime = 0f;

        while (elapsedTime < searchTime)
        {
            NavMeshAgent navAgent = agent;
            // When near the last known position, rotate to look around
            if (Vector3.Distance(navAgent.transform.position, lastKnownPosition.value) < 1f)
            {
                navAgent.transform.Rotate(0, Random.Range(-30f, 30f), 0);
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        EndAction(false);  // End the action so the behavior tree can continue (e.g., return to patrol)
    }
}
