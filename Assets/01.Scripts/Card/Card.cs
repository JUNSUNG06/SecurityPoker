using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private int number;

    public int Number
    {
        get
        {
            return number;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(眉农构矫扁())
        {
            GameObject.Find("Manager").GetComponent<CardManager>().SelectedCard = this.GetComponent<RectTransform>();
        }
    }

    private bool 眉农构矫扁()
    {
        Vector2 minPos;
        Vector2 maxPos;
        RectTransform pos;

        pos = GetComponent<RectTransform>();

        minPos = new Vector2(pos.rect.x - pos.rect.width / 2, pos.rect.y - pos.rect.height / 2);
        maxPos = new Vector2(pos.rect.x + pos.rect.width / 2, pos.rect.y + pos.rect.height / 2);

        if((Input.mousePosition.x >= minPos.x && Input.mousePosition.y >= minPos.y) && (Input.mousePosition.x <= maxPos.x && Input.mousePosition.y <= maxPos.y))
        {
            return true;
        }

        return false;
    }
}
