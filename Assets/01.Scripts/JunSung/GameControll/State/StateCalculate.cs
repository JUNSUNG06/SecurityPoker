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

    private int playerSetSocre;
    private int aiSetScore;


    public override void OnAwake()
    {
        StateText = stateMachineClass.StateText;

        //�ڵ�¥��......

    }

    public override void OnStart()
    {
        Debug.Log("callculate");
        Debug.Log("State Caculate Start");

        StateText.text = "Turn End";

        //GO,DIE �Ǵ�......

        if (PlayerPrefs.GetString("PlayerChoose") == "GO" && PlayerPrefs.GetString("AIChoose") == "GO")
        {
            BothGo = true;
        }
        else if (PlayerPrefs.GetString("PlayerChoose") == "GO" && PlayerPrefs.GetString("AIChoose") == "DIE")
        {
            PlayerOnlyGo = true;
        }
        else if (PlayerPrefs.GetString("PlayerChoose") == "DIE" && PlayerPrefs.GetString("AIChoose") == "GO")
        {
            AiOnlyGo = true;
        }
        else
        {
            BothDie = false;
        }

        CalculateScore();

        if (Mathf.Abs(ScoreManager.Instance.CompareScore()) >= 20 || CardManager.Instance.EmptyCard())
        {
            stateMachineClass.EndGame();
        }
        else
        {
            Debug.Log("chaange");
            OnTextMove();//�ý�Ʈ......
        }
    }

    public override void OnUpdate(float deltaTime)
    {
        /*if (Input.GetButtonDown("Fire1"))
        {
            if (BothGo == true)
            {

                //�Ѵ� GO�� �����ߴٸ�......

                OnTextMove();//�ý�Ʈ......
                BothGo = false;//�ݺ� ���ϰ� �ϱ�......
            }
            else if (PlayerOnlyGo == true)
            {

                //�÷��̾ GO�� �����ߴٸ�......

                OnTextMove();//�ý�Ʈ......
                PlayerOnlyGo = false;//�ݺ� ���ϰ� �ϱ�......
            }
            else if (AiOnlyGo == true)
            {

                //AI�� GO�� �����ߴٸ�......

                OnTextMove();//�ý�Ʈ......
                AiOnlyGo = false;//�ݺ� ���ϰ� �ϱ�......
            }
            else if (BothDie == true)
            {

                //�Ѵ� DIE�� �����ߴٸ�......

                OnTextMove();//�ý�Ʈ......
                BothDie = false;//�ݺ� ���ϰ� �ϱ�......
            }
        }*/
    }

    public override void OnEnd()
    {

        //���������� �����ϱ�......

        CardManager.Instance.ClearUsedCard();
        playerSetSocre = 0;
        aiSetScore = 0;
        BothGo = false;
        BothDie = false;
        AiOnlyGo = false;
        PlayerOnlyGo = false;

        StateText.text = "Turn End";
    }

    private void CalculateScore()
    {
        if(BothGo)
        {
            for(int i = 0; i < 3; i++)
            {
                playerSetSocre += CardManager.Instance.playerSettingCard[i].Number;
            }

            for(int i = 0; i < 3; i++)
            {
                aiSetScore += CardManager.Instance.aiSettingCard[i].Number;
            }

            ScoreManager.Instance.AddGameScore(playerSetSocre - aiSetScore, aiSetScore - playerSetSocre);
        }
        else if(PlayerOnlyGo)
        {
            ScoreManager.Instance.AddGameScore(2, 0);
        }
        else if(AiOnlyGo)
        {
            ScoreManager.Instance.AddGameScore(0, 2);
        }
        else if(BothDie)
        {
            ScoreManager.Instance.AddGameScore(0, 0);
        }
    }

    public override void OnTextMove()
    {
        StateText.transform.DOMove(Camera.main.WorldToScreenPoint(new Vector2(1, 0)), 1f).SetEase(Ease.OutQuint).OnComplete(() =>
        {
            StateText.transform.DOMove(Camera.main.WorldToScreenPoint(new Vector2(15, 0)), 1f).SetEase(Ease.InQuint).OnComplete(() =>
            {
                Debug.Log("???");
                stateMachine.ChangeState<StateSetting>();
            });
        });
    }
}
