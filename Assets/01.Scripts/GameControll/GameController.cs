using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private StateMachine<GameController> stateMachine;

    private void Start() 
    {
        stateMachine = new StateMachine<GameController>(this, new StateStart());
        stateMachine.AddState(new StateSetting());
        stateMachine.AddState(new StateChoose());
        stateMachine.AddState(new StateCalculate());
    }

    private void Update() 
    {
        stateMachine.Updata(Time.deltaTime);    
    }
}
