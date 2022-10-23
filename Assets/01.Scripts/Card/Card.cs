using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Card : MonoBehaviour, IPointerDownHandler, IPointerMoveHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
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
        if(selected)
        {
            rectTransform.anchoredPosition += eventData.delta;
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
        CardManager.Instance.SetCardScale(rectTransform, originSize * activeSize, chagneSizeDuration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CardManager.Instance.SetCardScale(rectTransform, originSize, chagneSizeDuration);
    }
}
