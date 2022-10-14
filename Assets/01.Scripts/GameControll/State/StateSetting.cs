using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StateSetting : State<GameController>
{
    private bool CardSeetting = false;
    private bool HiddenCardSeetting = false;
    private bool RandomCardSeetting = false;

    public override void OnAwake()
    {
        Debug.Log(2);

        //n��° �� �˷���......
        

    }

    public override void OnStart()
    {
        Debug.Log("State Setting Start");

        //�̶����� ī�弼�� ����......

    }

    public override void OnUpdate(float deltaTime)
    {
        //ī��1�弼��......(�÷��̾� + AI ���ÿ�)


            
        CardSeetting = true;

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

        if(RandomCardSeetting == true)
        {
            stateMachine.ChangeState<StateChoose>();
        }
    }

    public override void OnEnd()
    {
        Debug.Log("State Setting End");

        //�ڵ�¥��......

    }
}
