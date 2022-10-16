using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class StateCalculate : State<GameController>
{
    private TextMeshProUGUI StateText;

    private bool BothGo = false;
    private bool PlayerOnlyGo = false;
    private bool AiOnlyGo = false;
    private bool BothDie = false;

    public override void OnAwake()
    {
        StateText = stateMachineClass.StateText;
        Debug.Log(4);

        //코드짜기......

    }

    public override void OnStart()
    {
        Debug.Log("State Caculate Start");

        StateText.text = "Turn End";

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

            OnTextMove();//택스트......
            BothGo = false;//반복 못하게 하기......
        }
        else if(PlayerOnlyGo == true)
        {

            //플레이어만 GO를 선택했다면......

            OnTextMove();//택스트......
            PlayerOnlyGo = false;//반복 못하게 하기......
        }
        else if(AiOnlyGo == true)
        {

            //AI만 GO를 선택했다면......

            OnTextMove();//택스트......
            AiOnlyGo = false;//반복 못하게 하기......
        }
        else if(BothDie == true)
        {

            //둘다 DIE를 선택했다면......

            OnTextMove();//택스트......
            BothDie = false;//반복 못하게 하기......
        }
    }

    public override void OnEnd()
    {

        //다음판으로 정리하기......
        StateText.text = "Turn End";

        throw new System.NotImplementedException();
    }

    public override void OnTextMove()
    {
        StateText.transform.DOMove(Camera.main.WorldToScreenPoint(new Vector2(1, 0)), 1.5f).SetEase(Ease.OutExpo).OnComplete(() =>
        {
            StateText.transform.DOMove(Camera.main.WorldToScreenPoint(new Vector2(15, 0)), 1.5f).SetEase(Ease.InExpo).OnComplete(() =>
            {
                stateMachine.ChangeState<StateSetting>();
            });
        });
    }
}
