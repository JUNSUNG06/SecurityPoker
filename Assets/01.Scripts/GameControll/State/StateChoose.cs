using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChoose : State<GameController>
{
    private bool PlayerChoose = false;
    private bool AIChoose = false;

    public override void OnAwake()
    {
        Debug.Log(3);

        //���ý���......

    }

    public override void OnStart()
    {
        Debug.Log("State Choose Start");

        //�̶����� ���� ����......

    }

    public override void OnUpdate(float deltaTime)
    {
        PlayerChoose = true;

        //��ư �����ͼ� ��ư ����......

        if (true /* ���� �÷��̾ GO��ư�� �����ٸ�*/ && PlayerChoose == true)
        {
            PlayerPrefs.SetString("PlayerChoose", "GO");
            PlayerChoose = false;
            AIChoose = true;
        }
        else if(true /* �ƴϸ� �÷��̾ DIE��ư�� �����ٸ�*/ && PlayerChoose == true)
        {
            PlayerPrefs.SetString("PlayerChoose", "DIE");
            PlayerChoose = false;
            AIChoose = true;
        }

        if(true /* AI�� GO�� �����ϴ� ����/�˰���*/ && AIChoose == true)
        {
            PlayerPrefs.SetString("AIChoose", "GO");
            AIChoose = false;
        }
        else if(true /* AI�� DIE�� �����ϴ� ����/�˰���*/ && AIChoose == true)
        {
            PlayerPrefs.SetString("AIChoose", "DIE");
            AIChoose = false;
        }

        if(PlayerChoose == false && AIChoose == false)
        {
            stateMachine.ChangeState<StateCalculate>();
        }
    }

    public override void OnEnd()
    {
        Debug.Log("State Choose End");

        //��ư ��Ȱ��ȭ �� ����غ� + ī�� �� �����̼����� ������......

    }
}
