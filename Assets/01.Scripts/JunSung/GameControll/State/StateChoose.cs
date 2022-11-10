using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;

public class StateChoose : State<GameController>
{
    private TextMeshProUGUI StateText;
    private GameObject GoButton;
    private GameObject DieButton;
    private OnButtonClick onButtonClick;
    private Card allCard;

    private bool PlayerChoose = false;
    private bool AIChoose = false;
    private bool TextMove = false;

    public override void OnAwake()
    {
        StateText = stateMachineClass.StateText;
        GoButton = stateMachineClass.GoButton;
        DieButton = stateMachineClass.DieButton;
        onButtonClick = stateMachineClass.onButtonClick;
        Debug.Log(3);
    }

    public override void OnStart()
    {
        Debug.Log("State Choose Start");

        //이때부터 선택 가능......
        onButtonClick.Click = false;

        StateText.text = "Choose";
        OnTextMove();//택스트......


        //ai선택
        CardManager.Instance.AiChoose();
    }

    public override void OnUpdate(float deltaTime)
    {
        if(onButtonClick.Click == true && PlayerChoose == false)
        {
            onButtonClick.Click = false;
            PlayerChoose = true;
        }

        if(true /* AI가 GO를 선택하는 조건/알고리즘*/ && AIChoose == false)
        {
            PlayerPrefs.SetString("AIChoose", "GO");
            AIChoose = true;
        }
        else if(true /* AI가 DIE를 선택하는 조건/알고리즘*/ && AIChoose == false)
        {
            PlayerPrefs.SetString("AIChoose", "DIE");
            AIChoose = true;
        }

        if(PlayerChoose == true && AIChoose == true && TextMove == true)
        {
            stateMachine.ChangeState<StateCalculate>();
        }
    }

    public override void OnEnd()
    {
        Debug.Log("State Choose End");
        //버튼 비활성화 등 결과준비 + 카드 걍 로테이션으로 뒤집기......
        CardManager.Instance.AiChoose();

        if(PlayerPrefs.GetString("PlayerChoose") == "GO")
        {
            CardManager.Instance.playerSettingCard[0].OpenCard();
            CardManager.Instance.playerSettingCard[1].OpenCard();
            CardManager.Instance.playerSettingCard[2].OpenCard();
        }

        if (CardManager.Instance.aiIsGo)
        {
            CardManager.Instance.aiSettingCard[0].OpenCard();
            CardManager.Instance.aiSettingCard[1].OpenCard();
            CardManager.Instance.aiSettingCard[2].OpenCard();
        }
    }

    public override void OnTextMove()
    {
        StateText.transform.DOMove(Camera.main.WorldToScreenPoint(new Vector2(1, 0)), 1.5f).SetEase(Ease.OutExpo).OnComplete(() =>
        {
            StateText.transform.DOMove(Camera.main.WorldToScreenPoint(new Vector2(15, 0)), 1.5f).SetEase(Ease.InExpo).OnComplete(() =>
            {
                Debug.Log("조아");
                TextMove = true;
                GoButton.SetActive(true);
                DieButton.SetActive(true);
            });
        });
    }
}
