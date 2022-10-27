using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Setting : MonoBehaviour
{
    [SerializeField] GameObject settingCanvas;
    [SerializeField] GameObject settingWindow;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingCanvas.activeSelf == true)
            {
                SettingExit();
            }
            else if (settingCanvas.activeSelf == false)
            {
                CheckSetting();
            }
        }

    }

    public void CheckSetting()
    {
        settingCanvas.SetActive(true);
        settingWindow.transform.DOScale(new Vector3(1, 1, 1), .5f).SetEase(Ease.OutBack);
    }

    public void SettingExit()
    {
        settingWindow.transform.DOScale(new Vector3(0, 0, 0), .5f).SetEase(Ease.InBack);
        Invoke("Ss", .5f);
    }

    void Ss()
    {
        settingCanvas.SetActive(false);

    }
}
