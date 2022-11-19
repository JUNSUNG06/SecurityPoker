using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSoundManager : MonoBehaviour
{
    [SerializeField] Slider BGMSlider;
    //[SerializeField] AudioSource BGM;
    private AudioSource BGMSource;

    //[SerializeField] Slider effectSlider;
    //[SerializeField] AudioSource effectSound;

    //�����̴��� ���� ��������.

    private void Start()
    {
        BGMSource = GetComponent<AudioSource>();
    }

    public void BGMVolume(float volume)     //�����̴� value���� �޾ƿ� ���忡 �־��ֱ�.
    {
        BGMSource.volume = volume;
        //SoundDataManager.instance.sound.backGroundSound = BGM.volume;
        //SoundDataManager.instance.SaveData();
    }

    public void EffectSoundVolume(float volume)
    {
        //effectSound.volume = volume;
        //SoundDataManager.instance.sound.backGroundSound = BGM.volume;
        //SoundDataManager.instance.SaveData();
    }

}
