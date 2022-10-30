using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

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
    [SerializeField] GameObject recoredPrefab;
    [SerializeField] Color win;     //�÷��̾� ����
    [SerializeField] Color lose;
    [SerializeField] Color draw;    //���º�

    private int recordCount = 1;

    public static RecordManager instance;

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
        /*if (File.Exists(SoundAndRecordDataManager.instance.path + "Record"))
        {
            SoundAndRecordDataManager.instance.LoadData("Record");

            for (int i = 0; i < SoundAndRecordDataManager.instance.recordData.recordList.Count; i++)
            {
                Debug.Log("���ڵ� �ҷ�����~");
                CreateRecord(SoundAndRecordDataManager.instance.recordData.recordList[i].playerScore, 
                SoundAndRecordDataManager.instance.recordData.recordList[i].aiScore, 
                SoundAndRecordDataManager.instance.recordData.recordList[i].isWin, false);
            }
        }
        if (File.Exists(SoundAndRecordDataManager.instance.path))
        {
            Debug.Log("������ ����!");
        }*/

    }

    public void CreateRecord(int _playerScore, int _aiScore, int _isWin, bool _isNewCreat)
    {
        Debug.Log("�����Ǿ����ϴ�.");
        if (_isNewCreat)
        {
            Debug.Log("���� �����Ǿ����ϴ�.");
            Records record = new Records(_playerScore, _aiScore, _isWin);
            SoundAndRecordDataManager.instance.recordData.recordList.Add(record);
        }

        GameObject seeRecord = Instantiate(recoredPrefab, new Vector2(0, 0), Quaternion.identity);
        seeRecord.name = $"Record {recordCount}";
        recordCount++;
        seeRecord.transform.SetParent(ScrollView.transform);

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
