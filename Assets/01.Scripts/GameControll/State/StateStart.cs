using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStart : State<GameController>
{
    public override void OnAwake()
    {
        Debug.Log(1);
    }

    public override void OnStart()
    {
        Debug.Log("State Start Start");
    }

    public override void OnUpdate(float deltaTime)
    {
        stateMachine.ChangeState<StateSetting>();
    }

    public override void OnEnd()
    {
        Debug.Log("State Start End");
    }
}
