using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public StateMachine<GameController> stateMachine;

    public TextMeshProUGUI StateText;

    public GameObject GoButton;
    public GameObject DieButton;
    public OnButtonClick onButtonClick;

    private void Start()
    {
        stateMachine = new StateMachine<GameController>(this, new StateStart());
        stateMachine.AddState(new StateSetting());
        stateMachine.AddState(new StateChoose());
        stateMachine.AddState(new StateCalculate());

        GoButton.SetActive(false);
        DieButton.SetActive(false);
    }

    private void Update()
    {
        stateMachine.Updata(Time.deltaTime);
    }

    public void SetScore()
    {

    }
}
