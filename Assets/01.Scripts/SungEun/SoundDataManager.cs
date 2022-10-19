using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Sound
{
    public float backGroundSound = 0.5f;
    public float effectSound = 0.5f;
}

public class SoundDataManager : MonoBehaviour
{
    public static SoundDataManager instance;    //ΩÃ±€≈œ

    public Sound sound = new Sound();

    public string path; //¿˙¿Â ∞Ê∑Œ

    void Awake()
    {
        #region ΩÃ±€≈œ
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

        path = Application.persistentDataPath + "/SoundData";
        Debug.Log(path);
        SaveData();
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(sound);
        File.WriteAllText(path, data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path);
        sound = JsonUtility.FromJson<Sound>(data);
    }
}
