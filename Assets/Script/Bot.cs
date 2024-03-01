using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


public enum BotState
{
    idle,
    search,
    goFinish
}
public class Bot : Character
{
    //test
    [SerializeField] private TextMeshPro stateText;
    //
    [SerializeField] NavMeshAgent agent;
    private Transform brickListParent;
    private Vector3 destionation;

    private Transform finishPoint;

    //state machine
    private Dictionary<BotState, IState<Bot>> states;
    private IState<Bot> currentState;
    private void Start()
    {
        //init dictionary
        states = new Dictionary<BotState, IState<Bot>>
        {
            {BotState.idle,new Idle() },
            {BotState.search,new SearchBrick() },
            {BotState.goFinish,new GoFinish() }
        };
        currentState = states[BotState.idle];
        ChangeColor(colorType);
    }
    public NavMeshAgent GetAgent()
    {
        return agent;
    }
    //test
    public void ShowState(string stateStr)
    {
        stateText.text = stateStr;
    }
    public void ChangeState(BotState newState)
    {
        ShowState($"{newState.ToString()}");
        currentState.OnExit();
        currentState = states[newState];
        currentState.OnEnter(this);
    }
    public override void OnInit()
    {
        base.OnInit();
        ChangeAnimationState(Constants.ANIM_IDLE);
    }

    public void SetBrickListParent(Transform transform)
    {
        //parent of bricks on the current ground

        brickListParent = transform;
    }
    public Transform GetBrickListParent()
    {
        return brickListParent;
    }
    public void SetFinishPoint(Transform target)
    {
        if (finishPoint == null)
        {
            finishPoint = target;
        }

    }
    public Transform GetFinishPoint()
    {
        return finishPoint;
    }
    public Transform FindBrick()
    {
        int maxTry = 1000; 
        while (maxTry > 0) 
        {
            if (brickListParent != null && brickListParent.childCount > 0)
            {
                int rnd = Random.Range(0, brickListParent.childCount);
                Transform parent = brickListParent.GetChild(rnd);
                if (parent.childCount > 0)
                {
                    Transform target = parent.GetChild(0);
                    if (target.GetComponent<Brick>() != null && target.GetComponent<Brick>().colorType == colorType&&target.gameObject.activeSelf==true)
                    {
                        return target; 
                    }
                 
                    maxTry--;
                }
                else
                {
                  
                    maxTry--;
                }
            }
            else
            {
                return null;
            }
        }
        return null; 
    }

    private void Update()
    {
        if (GameManager.Instance.gameState == GameState.gameplay)
        {
            characterTf.forward = TF.forward;
            currentState.OnUpdate(this);
        }

        
    }

}
