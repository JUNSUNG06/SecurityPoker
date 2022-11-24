using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RecordManager : MonoBehaviour
{
    #region �ؼ��� �̰� ��������.
    /*private static RecordManager instance;
    public static RecordManager Instance
    {
        get
        {
            if(instance != null)
                return instance;

            return null;
        }
    }
    private void Awake()
    {
        if(instance == null)
            instance = this;
    }*/
    #endregion

    [SerializeField]  GameObject ScrollView;
    //[SerializeField]  GameObject ScrollViewHandle;
    [SerializeField] GameObject recoredPrefab;
    [SerializeField] Color win;     //�÷��̾� ����
    [SerializeField] Color lose;
    [SerializeField] Color draw;    //���º�

    private int recordCount = 1;

    public static RecordManager instance;
    Record record;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Intro")
        {
            record = FindObjectOfType<Record>();
            record.RecordCheck();
            ScrollView = GameObject.Find("RecordCanvas/RecordWindow/Scroll View/Viewport/Content");
            record.RecordExit();
            record.RealExit();
            //Debug.Log("�־���...?");
        }
    }

    public void CreateRecord(int _playerScore, int _aiScore, int _isWin, bool _isNewCreat)
    {
        //Debug.Log("�����Ǿ����ϴ�.");
        if (_isNewCreat)
        {
            //Debug.Log("���� �����Ǿ����ϴ�.");
            Records record = new Records(_playerScore, _aiScore, _isWin);
            SoundAndRecordDataManager.instance.recordData.recordList.Add(record);
            SoundAndRecordDataManager.instance.SaveData("Record");
            
        }
        else
        {
            GameObject seeRecord = Instantiate(recoredPrefab, new Vector2(0, 0), Quaternion.identity);
            seeRecord.name = $"Record {recordCount}";
            recordCount++;
            seeRecord.transform.SetParent(ScrollView.transform);
            seeRecord.transform.localScale = new Vector3(1, 1, 1);

            if (_playerScore > _aiScore && _isWin == 1)
            {
                seeRecord.GetComponent<Image>().color = win;
                seeRecord.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "��";

            }
            else if (_playerScore < _aiScore && _isWin == 2)
            {
                seeRecord.GetComponent<Image>().color = lose;
                seeRecord.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "��";
            }
            else if (_playerScore == _aiScore && _isWin == 3)
            {
                seeRecord.GetComponent<Image>().color = draw;
                seeRecord.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "���º�";
            }

            seeRecord.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = $"{_playerScore} : {_aiScore}";
        }
    }

}
