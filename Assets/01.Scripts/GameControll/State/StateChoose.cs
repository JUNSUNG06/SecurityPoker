using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChoose : State<GameController>
{
    public override void OnAwake()
    {
       Debug.Log(3);
    }

    public override void OnStart()
    {
        Debug.Log("State Choose Start");
    }

    public override void OnUpdate(float deltaTime)
    {
        stateMachine.ChangeState<StateCalculate>();
    }

    public override void OnEnd()
    {
        Debug.Log("State Choose End");
    }
}
