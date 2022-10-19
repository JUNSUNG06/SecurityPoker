using UnityEngine;

public class GameController : MonoBehaviour
{
    private StateMachine<GameController> stateMachine;
    
    public enum ChoiceCategory
    {
        GOGO = 0, 
        GODIE = 1,
        DIEGO = 2, 
        DIEDIE = 3
    }
    private ChoiceCategory choice;

    public ChoiceCategory Choice { get => choice; set => choice = value; }


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

    public void SetScore()
    {

    }
}
