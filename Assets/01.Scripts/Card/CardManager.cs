using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class CardManager : MonoBehaviour
{
    private static CardManager instance;

    public static CardManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.Log("null cardManager");
                return null;
            }

            return instance;
        }
    }

    [SerializeField] private RectTransform selectedCard;

    public RectTransform SelectedCard { get => selectedCard; set => selectedCard = value; }

    private Transform cardCanvas;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        cardCanvas = GameObject.Find("CardCanvas").GetComponent<Transform>();           
    }

    public static void OpenCard()
    {

    }

    public void ShowCardInformation()
    {

    }

    public void RandomCardSetting()
    {

    }

    public void SetCardScale(RectTransform card, Vector2 size, float duration)
    {
        if(SelectedCard == null)
        {
            card.SetAsLastSibling();
            card.DOScale(size, duration);
        }
    }
}
