using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class StateStart : State<GameController>
{
    private TextMeshProUGUI StateText;

    private bool CardDrawing = false;
    private bool TextMove = false;

    public override void OnAwake()
    {
        StateText = stateMachineClass.StateText;
        Debug.Log(1);

        //�� ó���� ���ӽ��� �ý�Ʈ......
        StateText.text = "GameStart!";
        OnTextMove();
    }

    public override void OnStart()
    {
    
        Debug.Log("State Start Start");

        //���ӵ���ȿ��......

    }

    public override void OnUpdate(float deltaTime)
    {

        //Ű�� �ޱ�(�ʿ� ���� ����)......

        CardDrawing = true;

        if (CardDrawing == true && TextMove == true)//���� ī�带 �޾Ҵٸ�
        {
            stateMachine.ChangeState<StateSetting>();
        }
    }

    public override void OnEnd()
    {

        Debug.Log("State Start End");

        //���۹���?......

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
