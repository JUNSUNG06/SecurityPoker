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
    public static SoundAndRecordDataManager instance;    //싱글턴

    public Sound sound = new Sound();   //Sound 사운드 클래스 생성

    public string path; //저장 경로

    void Awake()
    {
        #region 싱글턴
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
        //이 데이터가 될 변수를 사용하기 위해서

        Directory.CreateDirectory(Application.dataPath + @"\07.Data\"); //유니티 에셋 파일 내에 7.Data라는 파일을 새로 만들어 준것.
        path = Application.dataPath + @"\07.Data\SoundData";   // Application.dataPath는 유니티 에셋 내의 위치를 말함. 그래서 07.Data에 SoundData라는 제이슨 파일이 만들어짐.
        //Debug.Log(path);
        //Debug.Log(Application.persistentDataPath);
        SaveData();
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(sound);    //제이슨 데이터로 만들어줌.
        File.WriteAllText(path, data);      //파일에 써줌
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path);   //제이슨 데이터가 적힌 파일을 불러와줌
        sound = JsonUtility.FromJson<Sound>(data);      //데이터를 넣어줌.
    }
}
