using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchBrick : IState<Bot>
{
    private NavMeshAgent agent;
    private Transform target;
    private Transform brickContainer;
   
   
    public void OnEnter(Bot bot)
    {
        brickContainer = bot.GetBrickListParent();
        bot.ChangeAnimationState(Constants.ANIM_RUN);
        agent = bot.GetAgent();
        //set random target here
        target = bot.FindBrick();
    }

    public void OnExit()
    {
     
    }

    public void OnUpdate(Bot bot)
    {
        //bot.ShowState("Searching...");
        if (target==null)
        {
            //find new one
            target = bot.FindBrick();
            if (target == null)
            {
                //change to idle
                bot.ChangeState(BotState.idle);
            }
        }
        else
        {

            //check if color change
            if (target.GetComponent<Brick>().colorType != bot.colorType|| target.gameObject.activeSelf == false)
            {
                target = null;
                //return;
            }
            else
            {
                if (bot.GetBrickNumber() == Random.Range(4, 6))
                {
                    //change state here
                    bot.ChangeState(BotState.goFinish);
                }
                agent.SetDestination(target.position);
            }
    

        }
    }
}
