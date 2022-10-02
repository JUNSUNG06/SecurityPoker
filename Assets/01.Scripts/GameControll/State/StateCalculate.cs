using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCalculate : State<GameController>
{
    public override void OnAwake()
    {
        Debug.Log(4);
    }

    public override void OnStart()
    {
        Debug.Log("State Caculate Start");
    }

    public override void OnUpdate(float deltaTime)
    {
        Debug.Log("End Cycle");
    }

    public override void OnEnd()
    {
        throw new System.NotImplementedException();
    }
}
