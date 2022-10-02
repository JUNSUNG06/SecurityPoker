using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSetting : State<GameController>
{
    public override void OnAwake()
    {
        Debug.Log(2);
    }

    public override void OnStart()
    {
        Debug.Log("State Setting Start");
    }

    public override void OnUpdate(float deltaTime)
    {
        stateMachine.ChangeState<StateChoose>();
    }

    public override void OnEnd()
    {
        Debug.Log("State Setting End");
    }
}
