using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class RecordManager : MonoBehaviour
{
    #region 준성아 이거 설명해조.
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
    [SerializeField] Color win;     //플레이어 기준
    [SerializeField] Color lose;
    [SerializeField] Color draw;    //무승부

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
                Debug.Log("리코드 불러오깅~");
                CreateRecord(SoundAndRecordDataManager.instance.recordData.recordList[i].playerScore, 
                SoundAndRecordDataManager.instance.recordData.recordList[i].aiScore, 
                SoundAndRecordDataManager.instance.recordData.recordList[i].isWin, false);
            }
        }
        if (File.Exists(SoundAndRecordDataManager.instance.path))
        {
            Debug.Log("파일이 존재!");
        }*/

    }

    public void CreateRecord(int _playerScore, int _aiScore, int _isWin, bool _isNewCreat)
    {
        Debug.Log("생성되었습니다.");
        if (_isNewCreat)
        {
            Debug.Log("새로 생성되었습니다.");
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
            seeRecord.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "승";

        }
        else if (_playerScore < _aiScore && _isWin == 2)
        {
            seeRecord.GetComponent<Image>().color = lose;
            seeRecord.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "패";
        }
        else if (_playerScore == _aiScore && _isWin == 3)
        {
            seeRecord.GetComponent<Image>().color = draw;
            seeRecord.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "무승부";
        }

        seeRecord.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = $"{_playerScore} : {_aiScore}";

    }

}
