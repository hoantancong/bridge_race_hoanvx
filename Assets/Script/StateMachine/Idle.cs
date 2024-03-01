using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : IState<Bot>
{
    public void OnEnter(Bot bot)
    {
        bot.ChangeAnimationState(Constants.ANIM_IDLE);       
    }

    public void OnExit()
    {
        
    }

    public void OnUpdate(Bot bot)
    {
        //find brick
        if (bot.FindBrick()!= null)
        {
            bot.ChangeState(BotState.search);
        }        
    }
}