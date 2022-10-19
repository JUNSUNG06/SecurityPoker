using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StateSetting : State<GameController>
{
    private bool CardSeetting = false;
    private bool HiddenCardSeetting = false;
    private bool RandomCardSeetting = false;

    public override void OnAwake()
    {
        Debug.Log(2);

        //n번째 턴 알려줌......
        

    }

    public override void OnStart()
    {
        Debug.Log("State Setting Start");

        //이때부터 카드세팅 가능......

    }

    public override void OnUpdate(float deltaTime)
    {
        //카드1장세팅......(플레이어 + AI 동시에)


            
        CardSeetting = true;

        if(CardSeetting == true)
        {
            //뒷면카드1장세팅......



            HiddenCardSeetting = true;
        }

        if (HiddenCardSeetting == true)
        {
            //랜덤카드1장세팅......



            RandomCardSeetting = true;
        }

        if(RandomCardSeetting == true)
        {
            stateMachine.ChangeState<StateChoose>();
        }
    }

    public override void OnEnd()
    {
        Debug.Log("State Setting End");

        //코드짜기......

    }
}
