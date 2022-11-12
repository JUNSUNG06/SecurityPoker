using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public StateMachine<GameController> stateMachine;

    public TextMeshProUGUI StateText;

    public GameObject GoButton;
    public GameObject DieButton;
    public OnButtonClick onButtonClick;

    public bool canDarg = false;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

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

    public void EndGame()
    {
        GameObject.Find("Canvas/GameOver").GetComponent<EndGame>().ShowEndPanel();
    }
}
