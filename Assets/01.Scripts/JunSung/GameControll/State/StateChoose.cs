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

        //�̶����� ���� ����......
        onButtonClick.Click = false;

        stateMachineClass.isChoose = false;
        stateMachineClass.canChoose = false;

        StateText.text = "Choose";
        OnTextMove();//�ý�Ʈ......
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
        //��ư ��Ȱ��ȭ �� ����غ� + ī�� �� �����̼����� ������......
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
