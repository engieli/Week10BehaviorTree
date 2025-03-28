using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NodeCanvas.Framework;

public class ChasePlayer : ActionTask<NavMeshAgent>
{
    public BBParameter<Transform> player;  // Reference to the player

    protected override void OnExecute()
    {
        // Initialization not needed; the agent is automatically provided.
    }

    protected override void OnUpdate()
    {
        if (player.value != null)
        {
            NavMeshAgent navAgent = agent;
            navAgent.SetDestination(player.value.position);
        }
    }
}
