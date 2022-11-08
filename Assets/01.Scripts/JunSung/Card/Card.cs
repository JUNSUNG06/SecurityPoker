 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Card : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] public int amount;
    [SerializeField] private bool isfront;

    public int Number { get => number; set => number = value; }
    public int Amount { get => amount; set => amount = value; }

    [SerializeField] public TextMeshPro numberText;
    [SerializeField] public TextMeshPro amountText;

    GameController gameController;

    private bool isPlayerCard = false;
    public Vector2 originPos;
    Vector2 beforSettingPos;

    public Order order;
    public bool isClone = false;

    private void Awake()
    {
        beforSettingPos = transform.position;
        gameController = FindObjectOfType<GameController>();
        numberText = transform.GetChild(0).GetComponent<TextMeshPro>();
        amountText = transform.GetChild(1).GetComponent<TextMeshPro>();
        order = GetComponent<Order>();
    }
    private void Update()
    {
        if (CardManager.Instance.playerSettingCard.Count == 2)
        {
            RandomSet();
            CardManager.Instance.LastSetUp();
        }
        if(amount == 0)
        {
            CardManager.Instance.LowCard(number);
        }
    }

    public void SetUp(bool _isPlayer, int _number, int _amount, int _order)
    {
        isfront = _isPlayer;
        isPlayerCard = _isPlayer;
        number = _number;
        amount = _amount;
        originPos = transform.position;
        order.SetOriginOrder(_order);

        if(isfront)
        {
            numberText.text = number.ToString();
            amountText.text = "x" + amount.ToString();
        }
        else
        {
            numberText.text = "?";
            amountText.text = "";
        }
    }

    public void RandomSet()
    {

    }

    public void Setting(GameObject _cardPrefab, Vector2 _areaPos)
    {
        transform.position = originPos;
        amount--;
        amountText.text = amount.ToString();
        CreateClone(_cardPrefab, _areaPos);
    }

    public void CreateClone(GameObject _cardPrefab, Vector2 _areaPos)
    {
        GameObject cloneCardObj = Instantiate(_cardPrefab, Vector2.zero, Quaternion.identity);
        Card cloneCard = cloneCardObj.GetComponent<Card>();
        cloneCard.transform.position = _areaPos;
        cloneCard.Number = this.number;
        cloneCard.Amount = -1;
        cloneCard.numberText.text = cloneCard.Number.ToString();
        cloneCard.amountText.text = "";
        if(CardManager.Instance.dragCount >= 1)
        { 
            cloneCard.HideCard();
            cloneCard.isClone = true;
        }
        CardManager.Instance.playerSettingCard.Add(cloneCard);
    }

    public void OpenCard()
    {
        numberText.text = number.ToString();
    }

    public void HideCard()
    {
        numberText.text = "?";
        amountText.text = "";
    }

    private void OnMouseDown()
    {
        if(isPlayerCard && gameController.stateMachine.nowState.GetType() == gameController.stateMachine.stateList[typeof(StateSetting)].GetType() && CardManager.Instance.dragCount <= 1)
        {
            CardManager.Instance.MouseDownEvent(this.transform);
        }
    }

    private void OnMouseDrag()
    {
        if(isPlayerCard && gameController.stateMachine.nowState.GetType() == gameController.stateMachine.stateList[typeof(StateSetting)].GetType() && CardManager.Instance.dragCount <= 1)
        {
            CardManager.Instance.MouseDragEvent();
        }
    }

    private void OnMouseUp()
    {
        if(isPlayerCard && gameController.stateMachine.nowState.GetType() == gameController.stateMachine.stateList[typeof(StateSetting)].GetType() && CardManager.Instance.dragCount <= 1)
        {
            CardManager.Instance.MouseUpEvent();
        }
    }
}
