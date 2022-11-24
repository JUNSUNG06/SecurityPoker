using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public StateMachine<GameController> stateMachine;

    public TextMeshProUGUI StateText;

    public GameObject GoButton;
    public GameObject DieButton;
    public OnButtonClick onButtonClick;

    public bool canDarg = false;
    public bool canChoose = false;
    public bool isChoose { get; set; }

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

    public void Coroutine(Action action)
    {
        StartCoroutine(_Coroutine(action));
    }

    IEnumerator _Coroutine(Action _action)
    {
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        _action?.Invoke();
    }
}
