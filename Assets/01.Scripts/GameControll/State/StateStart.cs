using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStart : State<GameController>
{
    private bool CardDrawing = false;

    public override void OnAwake()
    {
        Debug.Log(1);

        //�ڵ�¥��......
    }

    public override void OnStart()
    {
    
        Debug.Log("State Start Start");

        //���ӵ���ȿ��......

    }

    public override void OnUpdate(float deltaTime)
    {
        CardDrawing = true;

        //Ű�� �ޱ�......

        CardDrawing = false;

        if (CardDrawing == false)//���� ī�带 �޾Ҵٸ�
        {
            stateMachine.ChangeState<StateSetting>();
        }
    }

    public override void OnEnd()
    {
        Debug.Log("State Start End");

        //���۹���?......

    }
}
