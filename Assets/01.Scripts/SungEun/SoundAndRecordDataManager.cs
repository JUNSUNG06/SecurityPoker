using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Sound  //소리저장 클래스
{
    public float backGroundSound = 0.5f;
    public float effectSound = 0.5f;
}

public class RecordData //전적 기록 클래스
{
    public List<Records> recordList = new List<Records>();
}

public class SoundAndRecordDataManager : MonoBehaviour
{
    public static SoundAndRecordDataManager instance;    //싱글턴

    public Sound sound = new Sound();   //Sound 클래스 생성

    public RecordData recordData = new RecordData();    //Record 클래스 생성

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
        //싱글턴은 어떤 데이터에 사용하는 변수를 어디에서든 사용하기 위해서

        Directory.CreateDirectory(Application.dataPath + @"\07.Data\"); //유니티 에셋 파일 내에 7.Data라는 파일을 새로 만들어 준것.
        path = Application.dataPath + @"\07.Data/";/* + "/SoundData";  */ // Application.dataPath는 유니티 에셋 내의 위치를 말함. 그래서 07.Data에 SoundData라는 제이슨 파일이 만들어짐.
        //path = Application.persistentDataPath + "/Save";
        
        //Debug.Log(path);
        if (File.Exists(path + "Sound"))  //만약 사운드 데이터 경로에 있다면 불러와줌.
        {
            Debug.Log("Sound 파일이 존재해서 불러왔어욥!");
            LoadData("Sound");
        }
        if (File.Exists(path + "Record"))
        {
            Debug.Log("Record 파일이 존재해서 불러왔어욥!");
            LoadData("Record");

            for (int i = 0; i < recordData.recordList.Count; i++)
            {
                Debug.Log("리코드 불러오깅~");
                Debug.Log($"{recordData.recordList[i].playerScore}, {recordData.recordList[i].aiScore}, {recordData.recordList[i].isWin}");

                Debug.Log(RecordManager.instance);

                RecordManager.instance.CreateRecord(
                    recordData.recordList[i].playerScore,
                recordData.recordList[i].aiScore, recordData.recordList[i].isWin, false);
            }
        }
        /*if (File.Exists(path))
        {
            Debug.Log("파일이 존재!");
        }*/

        SaveData("Sound");
    }

    private void Start()
    {
            Debug.Log(RecordManager.instance);
        
    }

    public void SaveData(string whatSave)
    {
        if (whatSave == "Sound")    //사운드 데이터를 저장 함.
        {
            Debug.Log("사운드를 저장합니다.");
            string data = JsonUtility.ToJson(sound);    //제이슨 데이터로 만들어줌.
            File.WriteAllText(path + "Sound", data);      //파일에 string으로 써 데이터를 저장함.

            if (File.Exists(path + "Sound"))
            {
                Debug.Log("Sound 파일이 존재합니담!");
            }
        }

        if (whatSave == "Record")
        {
            Debug.Log("전적을 저장합니다.");
            string data = JsonUtility.ToJson(recordData);
            File.WriteAllText(path + "Record", data);

            if (File.Exists(path + "Record"))
            {
                Debug.Log("Record 파일이 존재합니다!");
            }
        }
    }

    public void LoadData(string whatSave)
    {
        if (whatSave == "Sound")    //사운드 데이터르 불러와줌
        {
            string data = File.ReadAllText(path + "Sound");   //제이슨 데이터가 적힌 파일을 불러와줌
            sound = JsonUtility.FromJson<Sound>(data);      //데이터를 넣어줌.
        }

        if (whatSave == "Record")
        {
            string data = File.ReadAllText(path + "Record");
            recordData = JsonUtility.FromJson<RecordData>(data);
        }
    }
}
