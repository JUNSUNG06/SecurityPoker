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
    public bool CanSetting = false;

    public override void OnAwake()
    {
        CardManager.Instance.DragCount = 3;
        StateText = stateMachineClass.StateText;
        Debug.Log(2);
    }

    public override void OnStart()
    {
        Debug.Log("State Setting Start");


        StateText.text = "Card Setting";
        OnTextMove();//ÅÃ½ºÆ®......
    }

    public override void OnUpdate(float deltaTime)
    {
        if(CardManager.Instance.DragCount >= 3 && TextMove == true)
        {
            stateMachine.ChangeState<StateChoose>();
        }
    }

    public override void OnEnd()
    {
        Debug.Log("State Setting End");

        CanSetting = false;

    }

    public override void OnTextMove()
    {
        StateText.transform.DOMove(Camera.main.WorldToScreenPoint(new Vector2(1, 0)), 1.5f).SetEase(Ease.OutExpo).OnComplete(() =>
        {
            StateText.transform.DOMove(Camera.main.WorldToScreenPoint(new Vector2(15, 0)), 1.5f).SetEase(Ease.InExpo).OnComplete(() =>
            {
                TextMove = true;
                CardManager.Instance.DragCount = 0;
                CanSetting = true;
            });
        });
    }
}
