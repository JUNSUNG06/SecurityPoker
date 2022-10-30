using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Card : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] private int amount;
    [SerializeField] private bool isfront;

    public int Number { get => number; set => number = value; }
    public int Amount { get => amount; set => amount = value; }

    [SerializeField] public TextMeshPro numberText;
    [SerializeField] public TextMeshPro amountText;

    private bool isPlayerCard = false;
    public Vector2 originPos;

    public Order order;
    public bool isClone = false;

    private void Awake()
    {
        numberText = transform.GetChild(0).GetComponent<TextMeshPro>();
        amountText = transform.GetChild(1).GetComponent<TextMeshPro>();
        order = GetComponent<Order>();
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
        cloneCard.Amount = 0;
        cloneCard.numberText.text = cloneCard.Number.ToString();
        cloneCard.amountText.text = "";
        cloneCard.HideCard();
        cloneCard.isClone = true;
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
        if(isPlayerCard)
        {
            CardManager.Instance.MouseDownEvent(this.transform);
        }      
    }

    private void OnMouseDrag()
    {
        if(isPlayerCard)
        {
            CardManager.Instance.MouseDragEvent();
        }
    }

    private void OnMouseUp()
    {
        if(isPlayerCard)
        {
            CardManager.Instance.MouseUpEvent();
        }
    }
}
