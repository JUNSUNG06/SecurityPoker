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
    }

    public override void OnStart()
    {
        Debug.Log("State Choose Start");

        //이때부터 선택 가능......
        onButtonClick.Click = false;

        stateMachineClass.isChoose = false;
        stateMachineClass.canChoose = false;

        StateText.text = "Choose";
        OnTextMove();//택스트......
    }

    public override void OnUpdate(float deltaTime)
    {
        if(onButtonClick.Click == true && PlayerChoose == false)
        {
            onButtonClick.Click = false;
            PlayerChoose = true;
        }

        if (PlayerChoose == true && TextMove == true)
        {
            stateMachineClass.Coroutine(() => 
            {
                CardManager.Instance.ClearChooseText();
                stateMachine.ChangeState<StateCalculate>();
            });
        }

        if(stateMachineClass.isChoose)
        {
            GoButton.SetActive(true);
            DieButton.SetActive(true);
            stateMachineClass.isChoose = false;
            stateMachineClass.canChoose = false;
        }
    }

    public override void OnEnd()
    {
        Debug.Log("State Choose End");
        //버튼 비활성화 등 결과준비 + 카드 걍 로테이션으로 뒤집기......
        //CardManager.Instance.AiChoose();

        TextMove = false;
        PlayerChoose = false;
        AIChoose = false;
    }

    public override void OnTextMove()
    {
        StateText.transform.DOMove(Camera.main.WorldToScreenPoint(new Vector2(1, 0)), 1f).SetEase(Ease.OutQuint).OnComplete(() =>
        {
            StateText.transform.DOMove(Camera.main.WorldToScreenPoint(new Vector2(15, 0)), 1f).SetEase(Ease.InQuint).OnComplete(() =>
            {
                TextMove = true;
                stateMachineClass.canChoose = true;           
            });
        });
    }

    IEnumerator ChangeStateCalc()
    {
        yield return new WaitForSeconds(2f);


    }
}
