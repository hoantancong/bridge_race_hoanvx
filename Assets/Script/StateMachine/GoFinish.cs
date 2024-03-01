using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoFinish : IState<Bot>
{
    private NavMeshAgent agent;
    private Transform target;
    public void OnEnter(Bot bot)
    {
        agent = bot.GetAgent();
        target = bot.GetFinishPoint();
    }

    public void OnExit()
    {
       
    }

    public void OnUpdate(Bot bot)
    {
        Vector3 nextPos = bot.TF.position + bot.transform.forward*0.5f;
        if (bot.CanMove(nextPos))
        {
            agent?.SetDestination(target.position);
        }
        else
        {
            bot.ChangeState(BotState.search);
        }

    }
}
