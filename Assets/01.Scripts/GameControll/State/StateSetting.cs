using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class StateSetting : State<GameController>
{
    private TextMeshProUGUI StateText;

    private bool CardSeetting = false;
    private bool HiddenCardSeetting = false;
    private bool RandomCardSeetting = false;
    private bool TextMove = false;

    public override void OnAwake()
    {
        StateText = stateMachineClass.StateText;
        Debug.Log(2);
    }

    public override void OnStart()
    {
        Debug.Log("State Setting Start");

        //이때부터 카드세팅 가능

        StateText.text = "Card Setting";
        OnTextMove();//택스트......
    }

    public override void OnUpdate(float deltaTime)
    {
        //카드1장세팅......(플레이어 + AI 동시에)


        if (Input.GetButtonDown("Fire1")) { CardSeetting = true; }

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

        if(RandomCardSeetting == true && TextMove == true)
        {
            stateMachine.ChangeState<StateChoose>();
        }
    }

    public override void OnEnd()
    {
        Debug.Log("State Setting End");

        //코드짜기......

    }

    public override void OnTextMove()
    {
        StateText.transform.DOMove(Camera.main.WorldToScreenPoint(new Vector2(1, 0)), 1.5f).SetEase(Ease.OutExpo).OnComplete(() =>
        {
            StateText.transform.DOMove(Camera.main.WorldToScreenPoint(new Vector2(15, 0)), 1.5f).SetEase(Ease.InExpo).OnComplete(() =>
            {
                TextMove = true;
            });
        });
    }
}
