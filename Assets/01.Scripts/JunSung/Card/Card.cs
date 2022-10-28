using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Card : MonoBehaviour, IPointerDownHandler, IPointerMoveHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    private enum CardType
    {
        onHand,
        onDrag,
        set
    }
    private CardType currentType;

    private Vector2 originSize;

    private bool selected = false;

    [SerializeField] private float activeSize;
    [SerializeField] private float chagneSizeDuration;

    [SerializeField] private int number;

    public int Number
    {
        get
        {
            return number;
        }
    }

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        originSize = new Vector2(rectTransform.localScale.x, rectTransform.localScale.y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(1);

        if (CardManager.Instance.SelectedCard == null)
        {
            if (!selected)
            {
                CardManager.Instance.SelectedCard = this.GetComponent<RectTransform>();
                selected = true;
            }
        }
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if(currentType == CardType.onDrag)
        {
            if (selected)
            {
                rectTransform.anchoredPosition += eventData.delta;
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (CardManager.Instance.SelectedCard != null)
        {
            if (selected)
            {
                CardManager.Instance.SelectedCard = null;
                selected = false;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnPointerDownProcess();   
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnPointerUpProcess();
    }

    private void OnClickDownProcess()
    {
        switch (currentType)
        {
            case CardType.onHand:
                CardManager.Instance.SelectedCard = this.rectTransform;
                currentType = CardType.onDrag;
                selected = true;
                break;
            case CardType.onDrag:
                //
                break;
            case CardType.set:
                //
                break;
        }
    }

    private void OnClickUpProcess()
    {
        switch (currentType)
        {
            case CardType.onHand:
                //패로 돌아가는거
                break;
            case CardType.onDrag:
                CardManager.Instance.SelectedCard = null;
                selected = false;
                break;
            case CardType.set:
                CardManager.Instance.OpenCard(this.rectTransform);
                break;
        }
    }

    private void OnPointerDownProcess()
    {
        switch (currentType)
        {
            case CardType.onHand:
                CardManager.Instance.SetCardScale(rectTransform, originSize * activeSize, chagneSizeDuration);
                break;
            case CardType.onDrag:
                //
                break;
            case CardType.set:
                CardManager.Instance.ShowCardInformation();
                break;
        }
    }
    
    private void OnPointerUpProcess()
    {
        switch (currentType)
        {
            case CardType.onHand:
                CardManager.Instance.SetCardScale(rectTransform, originSize, chagneSizeDuration);
                break;
            case CardType.onDrag:
                //
                break;
            case CardType.set:
                CardManager.Instance.HideCardInformation();
                break;
        }
    }

    private bool OnSetArea()
    {
        return false;
    }
}
