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
            if (instance == null)
            {
                Debug.Log("null cardManager");
                return null;
            }

            return instance;
        }
    }

    [Header("[��� ���� ī��]")]
    [SerializeField] private List<Card> playerCards = new List<Card>();
    [SerializeField] private List<Card> aiCards = new List<Card>();

    [Header("[���õ� ī��]")]
    [SerializeField] public List<Card> playerSettingCard = new List<Card>();
    [SerializeField] private List<Card> aiSettingCard = new List<Card>();

    [Header("[ī�� ������]")]
    [SerializeField] private GameObject cardPrefab;

    [Header("[ī�� ���� ��ġ]")]
    public Transform playerCardTrm;
    public Transform aiCardTrm;

    [Header("[ī�� ���� ����]")]
    public Transform playerCardSettingArea;
    public Transform aiCardSettingArea;


    [Header("[����]")]
    [SerializeField] private bool isDragging;
    [SerializeField] private Transform selectedCard;
    [SerializeField] private LayerMask cardAreaLayer;
    public int DragCount;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            selectedCard.GetComponent<Card>().Setting(cardPrefab, playerCardSettingArea.position + new Vector3((playerSettingCard.Count - 1) * 1.75f, 0, 0));
            ++DragCount;
        }       
    }

    private void Update()
    {
        
    }
    public void LastSetUp()
    {
        int RandomCard = Random.Range(1, playerCards.Count + 1);
        selectedCard = playerCards[RandomCard].transform;
        Debug.Log(selectedCard.transform.position);
        playerSettingCard.Add(selectedCard.GetComponent<Card>());
        selectedCard.GetComponent<Card>().Setting(cardPrefab, playerCardSettingArea.position + new Vector3((playerSettingCard.Count - 1) * 1.75f, 0, 0));
        selectedCard.position = selectedCard.GetComponent<Card>().originPos;
        selectedCard = null;
        DragCount++;
        Debug.Log(DragCount);
    }

    public void CreateCard(bool _isPlayer, int _number, int _amount, Vector2 _position, int _order)
    {
        GameObject cardObj = Instantiate(cardPrefab, _position, Quaternion.identity);
        Card card = cardObj.GetComponent<Card>();
        
        if(_isPlayer)
        {
            card.SetUp(true, _number, _amount, _order);
            playerCards.Add(card);
        }
        else
        {
            card.SetUp(false, _number, _amount, _order);
            aiCards.Add(card);
        }
    }

    public void MouseDownEvent(Transform _card)
    {
        isDragging = true;
        selectedCard = _card;
    }

    public void MouseDragEvent()
    {
        selectedCard.position = Util.mousePosition;
    }

    public void MouseUpEvent()
    {
        isDragging = false;

        RaycastHit2D hit = Physics2D.Raycast(selectedCard.position, selectedCard.transform.forward, 6f, cardAreaLayer);
        if(hit)
        {
            playerSettingCard.Add(selectedCard.GetComponent<Card>());
            selectedCard.GetComponent<Card>().Setting(cardPrefab, playerCardSettingArea.position + new Vector3((playerSettingCard.Count - 1) * 1.75f, 0, 0));
            ++DragCount;
        }

        selectedCard.position = selectedCard.GetComponent<Card>().originPos;

        selectedCard = null;
    }
}
