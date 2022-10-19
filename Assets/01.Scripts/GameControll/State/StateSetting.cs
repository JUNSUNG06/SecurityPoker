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

        //�̶����� ī�弼�� ����

        StateText.text = "Card Setting";
        OnTextMove();//�ý�Ʈ......
    }

    public override void OnUpdate(float deltaTime)
    {
        //ī��1�弼��......(�÷��̾� + AI ���ÿ�)


        if (Input.GetButtonDown("Fire1")) { CardSeetting = true; }

        if(CardSeetting == true)
        {
            //�޸�ī��1�弼��......



            HiddenCardSeetting = true;
        }

        if (HiddenCardSeetting == true)
        {
            //����ī��1�弼��......



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

        //�ڵ�¥��......

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
