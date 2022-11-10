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
        path = Application.dataPath + @"\07.Data/";/* + "/SoundData";  */ // Application.dataPath�� ����Ƽ ���� ���� ��ġ�� ����. �׷��� 07.Data�� SoundData��� ���̽� ������ �������.
        //path = Application.persistentDataPath + "/Save";
        
        //Debug.Log(path);
        if (File.Exists(path + "Sound"))  //���� ���� ������ ��ο� �ִٸ� �ҷ�����.
        {
            Debug.Log("Sound ������ �����ؼ� �ҷ��Ծ��!");
            LoadData("Sound");
        }
        if (File.Exists(path + "Record"))
        {
            Debug.Log("Record ������ �����ؼ� �ҷ��Ծ��!");
            LoadData("Record");

            for (int i = 0; i < recordData.recordList.Count; i++)
            {
                Debug.Log("���ڵ� �ҷ�����~");
                Debug.Log($"{recordData.recordList[i].playerScore}, {recordData.recordList[i].aiScore}, {recordData.recordList[i].isWin}");

                Debug.Log(RecordManager.instance);

                RecordManager.instance.CreateRecord(
                    recordData.recordList[i].playerScore,
                recordData.recordList[i].aiScore, recordData.recordList[i].isWin, false);
            }
        }
        /*if (File.Exists(path))
        {
            Debug.Log("������ ����!");
        }*/

        SaveData("Sound");
    }

    private void Start()
    {
            Debug.Log(RecordManager.instance);
        
    }

    public void SaveData(string whatSave)
    {
        if (whatSave == "Sound")    //���� �����͸� ���� ��.
        {
            Debug.Log("���带 �����մϴ�.");
            string data = JsonUtility.ToJson(sound);    //���̽� �����ͷ� �������.
            File.WriteAllText(path + "Sound", data);      //���Ͽ� string���� �� �����͸� ������.

            if (File.Exists(path + "Sound"))
            {
                Debug.Log("Sound ������ �����մϴ�!");
            }
        }

        if (whatSave == "Record")
        {
            Debug.Log("������ �����մϴ�.");
            string data = JsonUtility.ToJson(recordData);
            File.WriteAllText(path + "Record", data);

            if (File.Exists(path + "Record"))
            {
                Debug.Log("Record ������ �����մϴ�!");
            }
        }
    }

    public void LoadData(string whatSave)
    {
        if (whatSave == "Sound")    //���� �����͸� �ҷ�����
        {
            string data = File.ReadAllText(path + "Sound");   //���̽� �����Ͱ� ���� ������ �ҷ�����
            sound = JsonUtility.FromJson<Sound>(data);      //�����͸� �־���.
        }

        if (whatSave == "Record")
        {
            string data = File.ReadAllText(path + "Record");
            recordData = JsonUtility.FromJson<RecordData>(data);
        }
    }
}
