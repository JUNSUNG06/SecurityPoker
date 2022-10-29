using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSoundManager : MonoBehaviour
{
    [SerializeField] Slider BGMSlider;
    //[SerializeField] AudioSource BGM;

    //[SerializeField] Slider effectSlider;
    //[SerializeField] AudioSource effectSound;

   //슬라이더와 사운드 가져오기.

    public void BGMVolume(float volume)     //슬라이더 value값을 받아와 사운드에 넣어주기.
    {
        //BGM.volume = volume;
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
