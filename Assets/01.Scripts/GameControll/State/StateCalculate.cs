using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class StateCalculate : State<GameController>
{
    private TextMeshProUGUI StateText;

    private bool BothGo = false;
    private bool PlayerOnlyGo = false;
    private bool AiOnlyGo = false;
    private bool BothDie = false;

    public override void OnAwake()
    {
        StateText = stateMachineClass.StateText;
        Debug.Log(4);

        //�ڵ�¥��......

    }

    public override void OnStart()
    {
        Debug.Log("State Caculate Start");

        StateText.text = "Turn End";

        //GO,DIE �Ǵ�......

        if (PlayerPrefs.GetString("PlayerChoose") == "GO" && PlayerPrefs.GetString("AIChoose") == "GO")
        {
            BothGo = true;
        }
        else if(PlayerPrefs.GetString("PlayerChoose") == "GO" && PlayerPrefs.GetString("AIChoose") == "DIE")
        {
            PlayerOnlyGo = true;
        }
        else if(PlayerPrefs.GetString("PlayerChoose") == "DIE" && PlayerPrefs.GetString("AIChoose") == "GO")
        {
            AiOnlyGo = true;
        }
        else
        {
            BothDie = false;
        }
    }

    public override void OnUpdate(float deltaTime)
    {
        if(BothGo == true)
        {

            //�Ѵ� GO�� �����ߴٸ�......

            OnTextMove();//�ý�Ʈ......
            BothGo = false;//�ݺ� ���ϰ� �ϱ�......
        }
        else if(PlayerOnlyGo == true)
        {

            //�÷��̾ GO�� �����ߴٸ�......

            OnTextMove();//�ý�Ʈ......
            PlayerOnlyGo = false;//�ݺ� ���ϰ� �ϱ�......
        }
        else if(AiOnlyGo == true)
        {

            //AI�� GO�� �����ߴٸ�......

            OnTextMove();//�ý�Ʈ......
            AiOnlyGo = false;//�ݺ� ���ϰ� �ϱ�......
        }
        else if(BothDie == true)
        {

            //�Ѵ� DIE�� �����ߴٸ�......

            OnTextMove();//�ý�Ʈ......
            BothDie = false;//�ݺ� ���ϰ� �ϱ�......
        }
    }

    public override void OnEnd()
    {

        //���������� �����ϱ�......
        StateText.text = "Turn End";

        throw new System.NotImplementedException();
    }

    public override void OnTextMove()
    {
        StateText.transform.DOMove(Camera.main.WorldToScreenPoint(new Vector2(1, 0)), 1.5f).SetEase(Ease.OutExpo).OnComplete(() =>
        {
            StateText.transform.DOMove(Camera.main.WorldToScreenPoint(new Vector2(15, 0)), 1.5f).SetEase(Ease.InExpo).OnComplete(() =>
            {
                stateMachine.ChangeState<StateSetting>();
            });
        });
    }
}
