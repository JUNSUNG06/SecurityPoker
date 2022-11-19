using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OnButtonClick : MonoBehaviour
{
    [SerializeField] List<GameObject> buttons = new List<GameObject>();
    public bool Click = false;
    public void GoClick()
    {
        Click = true;
        PlayerPrefs.SetString("PlayerChoose", "GO");
        for (int i = 0; i < buttons.Count; i++) { buttons[i].SetActive(false); }
        SoundManager.Instance.Pop("MP_Tick");
    }
    public void DieClick()
    {
        Click = true;
        PlayerPrefs.SetString("PlayerChoose", "DIE");
        for (int i = 0; i < buttons.Count; i++) { buttons[i].SetActive(false); }
        SoundManager.Instance.Pop("MP_Tick");
    }
}
