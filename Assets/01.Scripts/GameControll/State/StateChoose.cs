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

        //선택시작......

    }

    public override void OnStart()
    {
        Debug.Log("State Choose Start");

        //이때부터 선택 가능......

    }

    public override void OnUpdate(float deltaTime)
    {
        PlayerChoose = true;

        //버튼 가져와서 버튼 선택......

        if (true /* 만약 플레이어가 GO버튼을 눌럿다면*/ && PlayerChoose == true)
        {
            PlayerPrefs.SetString("PlayerChoose", "GO");
            PlayerChoose = false;
            AIChoose = true;
        }
        else if(true /* 아니면 플레이어가 DIE버튼을 눌럿다면*/ && PlayerChoose == true)
        {
            PlayerPrefs.SetString("PlayerChoose", "DIE");
            PlayerChoose = false;
            AIChoose = true;
        }

        if(true /* AI가 GO를 선택하는 조건/알고리즘*/ && AIChoose == true)
        {
            PlayerPrefs.SetString("AIChoose", "GO");
            AIChoose = false;
        }
        else if(true /* AI가 DIE를 선택하는 조건/알고리즘*/ && AIChoose == true)
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

        //버튼 비활성화 등 결과준비 + 카드 걍 로테이션으로 뒤집기......

    }
}
