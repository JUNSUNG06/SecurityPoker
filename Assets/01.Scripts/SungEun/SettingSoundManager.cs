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

    public void BGMVolume(float volume)
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
