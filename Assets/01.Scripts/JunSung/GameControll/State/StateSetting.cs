using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class StateSetting : State<GameController>
{
    private TextMeshProUGUI StateText;

    private bool TextMove = false;
    public bool CanSetting = false;

    public override void OnAwake()
    {
        CardManager.Instance.dragCount = 3;
        StateText = stateMachineClass.StateText;
    }

    public override void OnStart()
    {
        Debug.Log("State Setting Start");

        for (int j = 0; j < 5; j++) { CardManager.Instance.playerCards[j].gameObject.SetActive(true); CardManager.Instance.aiCards[j].gameObject.SetActive(true); }
        StateText.text = "Card Setting";
        OnTextMove();//ÅÃ½ºÆ®......
    }

    public override void OnUpdate(float deltaTime)
    {
        if(CardManager.Instance.dragCount >= 3 && TextMove == true)
        {
            //for (int i = 0; i < 5; i++) { CardManager.Instance.playerCards[i].gameObject.SetActive(false); CardManager.Instance.aiCards[i].gameObject.SetActive(false); }
            stateMachine.ChangeState<StateChoose>();
        }
    }

    public override void OnEnd()
    {
        Debug.Log("State Setting End");

        CardManager.Instance.dragCount = 0;
        TextMove = false;
        CanSetting = false;
    }

    public override void OnTextMove()
    {
        StateText.transform.DOMove(Camera.main.WorldToScreenPoint(new Vector2(1, 0)), 1.5f).SetEase(Ease.OutExpo).OnComplete(() =>
        {
            StateText.transform.DOMove(Camera.main.WorldToScreenPoint(new Vector2(15, 0)), 1.5f).SetEase(Ease.InExpo).OnComplete(() =>
            {
                TextMove = true;
                CardManager.Instance.dragCount = 0;
                CanSetting = true;
            });
        });
    }
}
