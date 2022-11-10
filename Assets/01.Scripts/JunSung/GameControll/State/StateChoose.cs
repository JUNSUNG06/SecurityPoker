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

        //�̶����� ���� ����......
        onButtonClick.Click = false;

        StateText.text = "Choose";
        OnTextMove();//�ý�Ʈ......


        //ai����
        CardManager.Instance.AiChoose();
    }

    public override void OnUpdate(float deltaTime)
    {
        if(onButtonClick.Click == true && PlayerChoose == false)
        {
            onButtonClick.Click = false;
            PlayerChoose = true;
        }

        if(true /* AI�� GO�� �����ϴ� ����/�˰���*/ && AIChoose == false)
        {
            PlayerPrefs.SetString("AIChoose", "GO");
            AIChoose = true;
        }
        else if(true /* AI�� DIE�� �����ϴ� ����/�˰���*/ && AIChoose == false)
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
        //��ư ��Ȱ��ȭ �� ����غ� + ī�� �� �����̼����� ������......
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
                Debug.Log("����");
                TextMove = true;
                GoButton.SetActive(true);
                DieButton.SetActive(true);
            });
        });
    }
}
