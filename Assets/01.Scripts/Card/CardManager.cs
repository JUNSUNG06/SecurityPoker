using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardManager : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform currentSelectedCard;

    public RectTransform SelectedCard { get => currentSelectedCard; set => currentSelectedCard = value; }

    public static void OpenCard()
    {

    }

    public void ShowCardInfomation()
    {

    }

    public void RandomCardSetting()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("on drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
        SelectedCard = null;
    }
}
