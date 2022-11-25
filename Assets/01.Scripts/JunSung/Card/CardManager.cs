using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using TMPro.EditorUtilities;
using Newtonsoft.Json.Linq;
using TMPro;

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

    [Header("[사용 가능 카드]")]
    [SerializeField] public List<Card> playerCards = new List<Card>();
    [SerializeField] public List<Card> aiCards = new List<Card>();

    [Header("[세팅된 카드]")]
    [SerializeField] public List<Card> playerSettingCard = new List<Card>();
    [SerializeField] public List<Card> aiSettingCard = new List<Card>();

    [Header("[사용한 카드 카드]")]
    [SerializeField] public List<Card> playerUsedCard = new List<Card>();
    [SerializeField] public List<Card> aiUsedCard = new List<Card>();

    [Header("[플레이어가 공개한 카드]")]
    [SerializeField] public Card playerOpenCard;

    [Header("[카드 프리펩]")]
    [SerializeField] private GameObject cardPrefab;

    [Header("[카드 생성 위치]")]
    public Transform playerCardTrm;
    public Transform aiCardTrm;

    [Header("[카드 세팅 구역]")]
    public Transform playerCardSettingArea;
    public Transform aiCardSettingArea;

    [Header("[사용한 카드 구역]")]
    public Transform playerUsedCardArea;
    public Transform aiUsedCardArea;


    [Header("[변수]")]
    [SerializeField] private bool isDragging;
    [SerializeField] private Transform selectedCard;
    [SerializeField] private LayerMask cardAreaLayer;
    public int dragCount;
    public bool aiIsGo;// true면 ai가 go, false면 die
    public string level;

    public TextMeshProUGUI aiChooseText;
    public TextMeshProUGUI playerChooseText;    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            //selectedCard.GetComponent<Card>().Setting(cardPrefab, playerCardSettingArea.position + new Vector3((playerSettingCard.Count - 1) * 1.75f, 0, 0));
            ++dragCount;
        }
    }

    private void Start()
    {
        level = PlayerPrefs.GetString("Difficulty");
        Debug.Log(level);
    }

    public void LastSetUp()
    {
        int[] cards = new int[100];
        int maxLength = 0;
        for(int i = 0; i < 5; i++)
        {
            for (int j = 0; j <= playerCards[i].amount - 1; j++)
            {
                cards[maxLength] = i;
                maxLength++;
            }
        }
        int RandomCard = Random.Range(0, maxLength - 1);
        Debug.Log(cards[RandomCard]);
        cardPrefab.transform.position = playerCards[cards[RandomCard]].transform.position;
        selectedCard = playerCards[cards[RandomCard]].transform;
        selectedCard.GetComponent<Card>().Setting(cardPrefab, playerCardSettingArea.position + new Vector3((playerSettingCard.Count) * 1.75f, 0, 0), true);
        selectedCard.position = selectedCard.GetComponent<Card>().originPos;
        selectedCard = null;
        dragCount++;
        SoundManager.Instance.Pop("MP__ (1)");
    }

    public void LowCard(int _number)
    {
        playerCards[_number - 1].gameObject.SetActive(false);
    }

    public void CreateCard(bool _isPlayer, int _number, int _amount, Vector2 _position, int _order)
    {
        GameObject cardObj = Instantiate(cardPrefab, _position, Quaternion.identity);
        cardObj.name = cardObj.name.Replace("(Clone)", "");
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

    public void AiSetCard()
    {
        int value = Random.Range(0, aiCards.Count);

        if (aiCards[value].Amount == 0)
        {
            AiSetCard();
            return;
        }
        cardPrefab.transform.position = aiCards[3].transform.position;
        aiCards[value].Setting(cardPrefab, aiCardSettingArea.position - new Vector3((aiSettingCard.Count) * 1.75f, 0, 0), false);

        Debug.Log("ai card set");
    }

    public void AiChoose()
    {
        if(level == "easy")
        {
            string a = Random.Range(0, 2) == 0 ? "GO" : "DIE";
            PlayerPrefs.SetString("AIChoose", a);
            aiIsGo = a switch
            {
                "GO" => true,
                "DIE" => false,
            };
        }
        else
        {
            int playerSide = PlayerFactor();
            int aiSide = AiFactor();

            if (playerSide < aiSide) //플레이어가 나보다 낮은 등급의 숫자일 때
            {
                PlayerPrefs.SetString("AIChoose", Random.Range(0, 6) == 0 ? "DIE" : "GO");
                aiIsGo = true;
            }
            else if (playerSide == aiSide) //플레이어랑 나랑 같은 등급의 숫자일 때
            {
                string a = Random.Range(0, 2) == 0 ? "GO" : "DIE";
                PlayerPrefs.SetString("AIChoose", a);
                aiIsGo = a switch
                {
                    "GO" => true,
                    "DIE" => false,
                };
            }
            else //플레이어가 나보다 높은 등급의 숫자일 때
            {
                PlayerPrefs.SetString("AIChoose", Random.Range(0, 6) == 0 ? "GO" : "DIE");
                aiIsGo = false;
            }
        }
    }

    public void ClearUsedCard()
    {
        int startGetUesdCard = 0;
        for(int i = 2; i >= 0; i--)
        {
            playerSettingCard[i].transform.DOMove(playerUsedCardArea.position, 0.4f).SetEase(Ease.InSine);
            playerUsedCard.Add(playerSettingCard[i]);
            playerSettingCard[i].HideCard();
            playerSettingCard[i].isSetting = false;
        }
            
        playerSettingCard.Clear();

        for (int i = 2; i >= 0; i--)
        {
            aiSettingCard[i].transform.DOMove(aiUsedCardArea.position, 0.4f).SetEase(Ease.InSine)
            .OnComplete(() => { ++startGetUesdCard; if (startGetUesdCard >= 3) { GetUesdCard(); } });
            aiUsedCard.Add(aiSettingCard[i]);
            aiSettingCard[i].HideCard();
            aiSettingCard[i].isSetting = false;
        }
            
        aiSettingCard.Clear();

        SoundManager.Instance.Pop("MP__ (1)");
    }

    private int PlayerFactor()
    {
        int setRetun = playerOpenCard.Number switch//휘성
        {
            1 => 0,
            2 => 0,
            3 => 1,
            4 => 2,
            5 => 2,
        };
        return setRetun;
    }

    private int AiFactor()
    {
        int rank = aiSettingCard[0].Number + aiSettingCard[1].Number + aiSettingCard[2].Number;
        if(rank >= 3 && rank <= 6) { return 0; }
        else if(rank >= 7 && rank <= 10) { return 1; }
        else { return 2; }
    }

    public void MouseDownEvent(Transform _card)
    {
        isDragging = true;
        selectedCard = _card;
        SoundManager.Instance.Pop("MP__ (1)");
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
            cardPrefab.transform.position = selectedCard.transform.position;
            selectedCard.GetComponent<Card>().Setting(cardPrefab, playerCardSettingArea.position + new Vector3((playerSettingCard.Count) * 1.75f, 0, 0), true);
            ++dragCount;
        }

        selectedCard.position = selectedCard.GetComponent<Card>().originPos;

        selectedCard = null;
    }

    public void GetUesdCard()
    {
        int playerCardIndex = UnityEngine.Random.Range(0, playerUsedCard.Count);
        int aiCardIndex = UnityEngine.Random.Range(0, aiUsedCard.Count);

        Card playerCard = playerUsedCard[playerCardIndex];
        Card aiCard = aiUsedCard[aiCardIndex];

        for (int i = 0; i < playerCards.Count; i++)
        {
            if (playerCard.Number == i + 1)
            {
                Debug.Log(playerCard.Number);
                Debug.Log(i + 1);
                playerCards[i].SetAmount(playerCards[i].Amount + 1, true);
                playerUsedCard.RemoveAt(playerCardIndex);
                playerCard.transform.DOMove(playerCards[playerCard.amount].transform.position, 0.4f).SetEase(Ease.InSine)
                .OnComplete(() => { Destroy(playerCard.gameObject); });
            }

            if (aiCard.Number == i + 1)
            {
                aiCards[i].SetAmount(aiCards[i].Amount + 1, false);
                aiUsedCard.RemoveAt(aiCardIndex);
                aiCard.transform.DOMove(aiCards[aiCard.amount].transform.position, 0.4f).SetEase(Ease.InSine)
                .OnComplete(() => { Destroy(aiCard.gameObject); });
            }

        Debug.Log("Get used card");
        }
    }

    public bool EmptyCard()
    {
        for(int i = 0; i < playerCards.Count; i++)
        {
            if (playerCards[i].Amount != 0)
                return false;
        }

        return true;
    }

    public void ChooseCard(Card card)
    {
        playerOpenCard = card;
        card.OpenCard();
        if(level == "hard")
        {
            int playerSide = PlayerFactor();
            int aiSide = AiFactor();

            if (playerSide < aiSide) //플레이어가 나보다 낮은 등급의 숫자일 때
            {
                Card temp;
                for (int i = 0; i < aiSettingCard.Count; i++)
                {
                    for (int j = 0; j < aiSettingCard.Count - (i + 1); j++)
                    {
                        if (aiSettingCard[j].Number > aiSettingCard[j + 1].Number)
                        {
                            temp = aiSettingCard[j];
                            aiSettingCard[j] = aiSettingCard[j + 1];
                            aiSettingCard[j + 1] = temp;
                        }
                    }
                }
                aiSettingCard[0].OpenCard();
            }
            else if (playerSide == aiSide) //플레이어랑 나랑 같은 등급의 숫자일 때
            {
                aiSettingCard[UnityEngine.Random.Range(0, 3)].OpenCard();
            }
            else //플레이어가 나보다 높은 등급의 숫자일 때
            {
                Card temp;
                for(int i = 0; i < aiSettingCard.Count; i++)
                {
                    for(int j = 0; j < aiSettingCard.Count - (i + 1); j++)
                    {
                        if (aiSettingCard[j].Number < aiSettingCard[j + 1].Number)
                        {
                            temp = aiSettingCard[j];
                            aiSettingCard[j] = aiSettingCard[j + 1];
                            aiSettingCard[j + 1] = temp;
                        }
                    }
                }
                aiSettingCard[0].OpenCard();
            }
        }
        else
        {
            aiSettingCard[UnityEngine.Random.Range(0, 3)].OpenCard();
        }
        AiChoose();
        SoundManager.Instance.Pop("MP__ (1)");
    }

    public void ClearChooseText()
    {
        aiChooseText.text = "";
        playerChooseText.text = "";
    }

    public void SetChooseText()
    {
        aiChooseText.text = aiIsGo ? "GO" : "DIE";
        playerChooseText.text = PlayerPrefs.GetString("PlayerChoose") == "GO" ? "GO" : "DIE";
    }
}
