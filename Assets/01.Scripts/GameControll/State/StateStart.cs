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

        //맨 처음에 게임시작 택스트......
        StateText.text = "GameStart!";
        OnTextMove();
    }

    public override void OnStart()
    {
    
        Debug.Log("State Start Start");

        //게임도입효과......

    }

    public override void OnUpdate(float deltaTime)
    {

        //키드 받기(필요 없을 수도)......

        CardDrawing = true;

        if (CardDrawing == true && TextMove == true)//만약 카드를 받았다면
        {
            stateMachine.ChangeState<StateSetting>();
        }
    }

    public override void OnEnd()
    {

        Debug.Log("State Start End");

        //시작문구?......

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
