using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStart : State<GameController>
{
    private bool CardDrawing = false;

    public override void OnAwake()
    {
        Debug.Log(1);

        //코드짜기......
    }

    public override void OnStart()
    {
    
        Debug.Log("State Start Start");

        //게임도입효과......

    }

    public override void OnUpdate(float deltaTime)
    {
        CardDrawing = true;

        //키드 받기......

        CardDrawing = false;

        if (CardDrawing == false)//만약 카드를 받았다면
        {
            stateMachine.ChangeState<StateSetting>();
        }
    }

    public override void OnEnd()
    {
        Debug.Log("State Start End");

        //시작문구?......

    }
}
