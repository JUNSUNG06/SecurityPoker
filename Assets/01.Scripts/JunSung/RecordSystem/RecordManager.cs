using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordManager : MonoBehaviour
{
    private static RecordManager instance;
    public static RecordManager Instance
    {
        get
        {
            if(instance != null)
                return instance;

            return null;
        }
    }

    public List<Record> recordList = new List<Record>();

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void CreateRecord(int _playerScore, int _aiScore, bool _isWin)
    {
        Record record = new Record(_playerScore, _aiScore, _isWin);
        recordList.Add(record);
    }
}
