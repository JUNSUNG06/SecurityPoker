using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingSoundManager : MonoBehaviour
{
    [SerializeField] Slider BGMSlider;
    //[SerializeField] AudioSource BGM;
    private AudioSource BGMSource;

    //[SerializeField] Slider effectSlider;
    //[SerializeField] AudioSource effectSound;

    //슬라이더와 사운드 가져오기.

    Setting setting;

    private void Start()
    {
        BGMSource = GetComponent<AudioSource>();
        BGMSource.volume = SoundAndRecordDataManager.instance.sound.backGroundSound;
        BGMSlider.value = SoundAndRecordDataManager.instance.sound.backGroundSound;
        SoundManager.Instance.SetVolume(BGMSlider.value);
    }

    public void BGMVolume(float volume)     //슬라이더 value값을 받아와 사운드에 넣어주기.
    {
        BGMSource.volume = volume;
        SoundAndRecordDataManager.instance.sound.backGroundSound = BGMSource.volume;
        SoundAndRecordDataManager.instance.SaveData("Sound");
        SoundManager.Instance.SetVolume(BGMSlider.value);
    }

    public void EffectSoundVolume(float volume)
    {
        //effectSound.volume = volume;
        //SoundDataManager.instance.sound.backGroundSound = BGM.volume;
        //SoundDataManager.instance.SaveData();
    }

}
