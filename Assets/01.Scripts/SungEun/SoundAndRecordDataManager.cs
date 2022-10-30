using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Sound  //�Ҹ����� Ŭ����
{
    public float backGroundSound = 0.5f;
    public float effectSound = 0.5f;
}

public class RecordData //���� ��� Ŭ����
{
    public List<Records> recordList = new List<Records>();
}

public class SoundAndRecordDataManager : MonoBehaviour
{
    public static SoundAndRecordDataManager instance;    //�̱���

    public Sound sound = new Sound();   //Sound Ŭ���� ����

    public RecordData recordData = new RecordData();    //Record Ŭ���� ����

    public string path; //���� ���

    void Awake()
    {
        #region �̱���
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        #endregion
        //�̱����� � �����Ϳ� ����ϴ� ������ ��𿡼��� ����ϱ� ���ؼ�

        Directory.CreateDirectory(Application.dataPath + @"\07.Data\"); //����Ƽ ���� ���� ���� 7.Data��� ������ ���� ����� �ذ�.
        path = Application.dataPath + @"\07.Data\SoundData";   // Application.dataPath�� ����Ƽ ���� ���� ��ġ�� ����. �׷��� 07.Data�� SoundData��� ���̽� ������ �������.
        //Debug.Log(path);
        //Debug.Log(Application.persistentDataPath);
        if (File.Exists(path))  //���� ���� ������ ��ο� �ִٸ� �ҷ�����.
        {
            LoadData("Sound");
        }

        SaveData("Sound");
    }

    public void SaveData(string whatSave)
    {
        if (whatSave == "Sound")    //���� �����͸� ���� ��.
        {
            string data = JsonUtility.ToJson(sound);    //���̽� �����ͷ� �������.
            File.WriteAllText(path, data);      //���Ͽ� string���� �� �����͸� ������.
        }

        if (whatSave == "Record")
        {
            string data = JsonUtility.ToJson(recordData);
            File.WriteAllText(path, data);
        }
    }

    public void LoadData(string whatSave)
    {
        if (whatSave == "Sound")    //���� �����͸� �ҷ�����
        {
            string data = File.ReadAllText(path);   //���̽� �����Ͱ� ���� ������ �ҷ�����
            sound = JsonUtility.FromJson<Sound>(data);      //�����͸� �־���.
        }

        if (whatSave == "Record")
        {
            string data = File.ReadAllText(path);
            recordData = JsonUtility.FromJson<RecordData>(data);
        }
    }
}
