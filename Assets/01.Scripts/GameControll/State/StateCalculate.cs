using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCalculate : State<GameController>
{
    private bool BothGo = false;
    private bool PlayerOnlyGo = false;
    private bool AiOnlyGo = false;
    private bool BothDie = false;

    public override void OnAwake()
    {
        Debug.Log(4);

        //코드짜기......

    }

    public override void OnStart()
    {
        Debug.Log("State Caculate Start");

        //GO,DIE 판단......

        if (PlayerPrefs.GetString("PlayerChoose") == "GO" && PlayerPrefs.GetString("AIChoose") == "GO")
        {
            BothGo = true;
        }
        else if(PlayerPrefs.GetString("PlayerChoose") == "GO" && PlayerPrefs.GetString("AIChoose") == "DIE")
        {
            PlayerOnlyGo = true;
        }
        else if(PlayerPrefs.GetString("PlayerChoose") == "DIE" && PlayerPrefs.GetString("AIChoose") == "GO")
        {
            AiOnlyGo = true;
        }
        else
        {
            BothDie = false;
        }
    }

    public override void OnUpdate(float deltaTime)
    {
        if(BothGo == true)
        {

            //둘다 GO를 선택했다면......

        }
        else if(PlayerOnlyGo == true)
        {

            //플레이어만 GO를 선택했다면......

        }
        else if(AiOnlyGo == true)
        {

            //AI만 GO를 선택했다면......

        }
        else if(BothDie == true)
        {

            //둘다 DIE를 선택했다면......

            stateMachine.ChangeState<StateSetting>();
        }
    }

    public override void OnEnd()
    {

        //다음판으로 정리하기......
                
        throw new System.NotImplementedException();
    }
}
