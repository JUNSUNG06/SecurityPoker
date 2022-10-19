using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCalculate : State<GameController>
{
    private bool BothGo = false;
    private bool PlayerOnlyGo = false;
    private bool AiOnlyGo = false;
    private bool BothDie = false;

    public override void OnAwake()
    {
        Debug.Log(4);

        //�ڵ�¥��......

    }

    public override void OnStart()
    {
        Debug.Log("State Caculate Start");

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

        }
        else if(PlayerOnlyGo == true)
        {

            //�÷��̾ GO�� �����ߴٸ�......

        }
        else if(AiOnlyGo == true)
        {

            //AI�� GO�� �����ߴٸ�......

        }
        else if(BothDie == true)
        {

            //�Ѵ� DIE�� �����ߴٸ�......

            stateMachine.ChangeState<StateSetting>();
        }
    }

    public override void OnEnd()
    {

        //���������� �����ϱ�......
                
        throw new System.NotImplementedException();
    }
}
