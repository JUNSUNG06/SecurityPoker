using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Sound
{
    public float backGroundSound = 0.5f;
    public float effectSound = 0.5f;
}

public class SoundAndRecordDataManager : MonoBehaviour
{
    public static SoundAndRecordDataManager instance;    //�̱���

    public Sound sound = new Sound();   //Sound ���� Ŭ���� ����

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
        //�� �����Ͱ� �� ������ ����ϱ� ���ؼ�

        Directory.CreateDirectory(Application.dataPath + @"\07.Data\"); //����Ƽ ���� ���� ���� 7.Data��� ������ ���� ����� �ذ�.
        path = Application.dataPath + @"\07.Data\SoundData";   // Application.dataPath�� ����Ƽ ���� ���� ��ġ�� ����. �׷��� 07.Data�� SoundData��� ���̽� ������ �������.
        //Debug.Log(path);
        //Debug.Log(Application.persistentDataPath);
        SaveData();
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(sound);    //���̽� �����ͷ� �������.
        File.WriteAllText(path, data);      //���Ͽ� ����
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path);   //���̽� �����Ͱ� ���� ������ �ҷ�����
        sound = JsonUtility.FromJson<Sound>(data);      //�����͸� �־���.
    }
}
