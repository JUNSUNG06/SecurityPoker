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

    private Order order;
    public bool isClone = false;
    public bool isSetting = false;
    public bool isHide = false;

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
            CardManager.Instance.LastSetUp();
        }
        if(amount == 0)
        {
            //CardManager.Instance.LowCard(number);
        }
    }

    public void SetUp(bool _isPlayer, int _number, int _amount, int _order)
    {
        isfront = _isPlayer;
        isPlayerCard = _isPlayer;
        number = _number;
        amount = _amount;
        originPos = transform.position;
        order.SetOrder(_order);

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

    public void Setting(GameObject _cardPrefab, Vector2 _areaPos, bool isPlayer)
    {
        --amount;

        if(isPlayer)
        {
            transform.position = originPos;
            amountText.text = "x" + amount.ToString();
        }
            
        CreateClone(_cardPrefab, _areaPos, isPlayer).HideCard();

        if(isPlayer)
        {
            CardManager.Instance.AiSetCard();
        }
    }

    public Card CreateClone(GameObject _cardPrefab, Vector2 _areaPos, bool isPlayer)
    {
        GameObject cloneCardObj = Instantiate(_cardPrefab, _cardPrefab.transform.position, Quaternion.identity);
        Card cloneCard = cloneCardObj.GetComponent<Card>();
        cloneCard.transform.DOMove(_areaPos, 0.4f).SetEase(Ease.InSine);
        cloneCard.Number = this.number;
        cloneCard.Amount = 0;
        //cloneCard.numberText.text = cloneCard.Number.ToString();
        //cloneCard.amountText.text = "";
        /*if(CardManager.Instance.dragCount >= 1)
        { 
            cloneCard.HideCard();
            cloneCard.isClone = true;
        }*/

        //cloneCard.HideCard();
        cloneCard.isClone = true;
        cloneCard.isSetting = true;
        cloneCard.isPlayerCard = isPlayer;

        if (isPlayer)
        {
            CardManager.Instance.playerSettingCard.Add(cloneCard);
        }
        else
        {
            CardManager.Instance.aiSettingCard.Add(cloneCard);
        }

        return cloneCard;
    }

    public void OpenCard()
    {
        numberText.text = number.ToString();
        numberText.color = new Color(0, 0, 0, 1);
        isHide = false;
    }

    public void HideCard()
    {
        numberText.text = "?";
        amountText.text = "";
        isHide = true;
    }

    public void SetAmount(int value, bool isPlayer)
    {
        amount = value;
        if(isPlayer)
            amountText.text = $"x{amount}";

        Debug.Log("set amount");
    }

    public void ShowInfo()
    {
        numberText.text = this.Number.ToString();
        numberText.color = new Color(0, 0, 0, 0.35f);
    }

    private void OnMouseDown()
    {
        if(isPlayerCard && gameController.stateMachine.nowState.GetType() == gameController.stateMachine.stateList[typeof(StateSetting)].GetType() && CardManager.Instance.dragCount <= 1)
        {
            CardManager.Instance.MouseDownEvent(this.transform);
        }
        else if (GameController.Instance.stateMachine.nowState.GetType() == typeof(StateChoose) && isSetting && isPlayerCard && isHide && gameController.canChoose)
        {
            CardManager.Instance.ChooseCard(this);
            gameController.isChoose = true;
        }
    }

    private void OnMouseDrag()
    {
        if(isPlayerCard && gameController.stateMachine.nowState.GetType() == gameController.stateMachine.stateList[typeof(StateSetting)].GetType() && GameController.Instance.canDarg)
        {
            if(amount > 0)
            {
                CardManager.Instance.MouseDragEvent();
            }          
        }
    }

    private void OnMouseUp()
    {
        if(isPlayerCard && gameController.stateMachine.nowState.GetType() == gameController.stateMachine.stateList[typeof(StateSetting)].GetType() && CardManager.Instance.dragCount <= 1)
        {
            CardManager.Instance.MouseUpEvent();
        }
    }

    private void OnMouseEnter()
    {
        if(GameController.Instance.stateMachine.nowState.GetType() == typeof(StateChoose) && isSetting && isPlayerCard && isHide && gameController.canChoose)
        {
            ShowInfo();
        }
    }
    private void OnMouseExit()
    {
        if (GameController.Instance.stateMachine.nowState.GetType() == typeof(StateChoose) && isSetting && isPlayerCard && isHide)
        {
            HideCard();
            numberText.color = new Color(0, 0, 0, 255);
        }
    }
}
