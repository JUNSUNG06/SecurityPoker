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
        //ī�� ����
        CreateCard();
    }

    public override void OnUpdate(float deltaTime)
    {

        //Ű�� �ޱ�(�ʿ� ���� ����)......
        if (Input.GetButtonDown("Fire1")) { CardDrawing = true; }

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

    private void CreateCard()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == 0)
                {
                    Vector2 pos = (CardManager.Instance.playerCardTrm.position + new Vector3(j, 0, 0));
                    CardManager.Instance.CreateCard(true, j + 1, 5 - j, pos, j + 1);
                }
                else
                {
                    Vector2 pos = (CardManager.Instance.aiCardTrm.position + new Vector3(-j, 0, 0));
                    CardManager.Instance.CreateCard(false, j + 1, 5 - j, pos, j + 1);
                }
            }
        }
    }
}
