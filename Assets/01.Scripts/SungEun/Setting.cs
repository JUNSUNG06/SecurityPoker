using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Setting : MonoBehaviour
{
    [SerializeField] GameObject settingCanvas;  //셋팅관련 캔버스
    [SerializeField] GameObject settingWindow;     //셋팅 창

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //셋팅창이 안 켜져 있을 때 ESC키를 누르면 나타나고 나타나 있을 때는 사라지기
        {
            if (settingCanvas.activeSelf == true)
            {
                SettingExit();
            }
            else if (settingCanvas.activeSelf == false)
            {
                SettingCheck();
            }
        }

    }

    public void SettingCheck()
    {
        settingCanvas.SetActive(true);      //셋팅 캔버스 활성화
        settingWindow.transform.DOScale(new Vector3(1, 1, 1), .5f).SetEase(Ease.OutBack);   //셋팅창 나타나기
        StartCoroutine(wait(1));
    }

    public void SettingExit()
    {
        Time.timeScale = 1;     //시간 정상으로 되돌리기
        settingWindow.transform.DOScale(new Vector3(0, 0, 0), .5f).SetEase(Ease.InBack);    //셋팅창 사라지기
        StartCoroutine(wait(2));    //셋팅 캔버스의 사라지는 시간은 0.5초 이후에 셋팅창이 사라지는 시간이 0.5초라서
    }

    IEnumerator wait(int oneOrTwo)
    {
        yield return new WaitForSeconds(.5f);   //0.5초 기다리기

        if (oneOrTwo == 1) Time.timeScale = 0;  //0.5초 뒤에 시간을 없에야 창이 똑바로 뜸.
        if (oneOrTwo == 2) settingCanvas.SetActive(false);      //셋팅 캔버스의 비활성화는 다 사라진 0.5초 이후에
    }
}
