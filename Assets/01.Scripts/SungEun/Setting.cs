using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    [SerializeField] GameObject settingCanvas;  //셋팅관련 캔버스
    [SerializeField] GameObject settingWindow;     //셋팅 창

    [SerializeField] Button panel = null;

    #region 시발
    /*private void Awake()
    {
        *//*settingCanvas.transform.localScale = new Vector3(1, 1, 1);
        settingCanvas.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        settingWindow.transform.localScale = new Vector3(1, 1);
        settingWindow.transform.localScale = new Vector3(0, 0);*//*
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //셋팅창이 안 켜져 있을 때 ESC키를 누르면 나타나고 나타나 있을 때는 사라지기
        {
            if (settingCanvas.activeSelf == true)
            {
                Debug.Log("셋팅창 꺼짐");
                SettingExit();
            }
            else if (settingCanvas.activeSelf == false)
            {
                SettingCheck();
                Debug.Log("셋팅창 켜짐");
                if (SceneManager.GetActiveScene().name == "Play")
                {
                    panel.interactable = true;
                }
            }
        }
    }

    public void SettingCheck()
    {
        settingCanvas.SetActive(true);      //셋팅 캔버스 활성화
        if (true)
        {
            settingWindow.transform.localScale = new Vector3(0, 0);
            //settingWindow.transform.DOScale(new Vector3(1, 1), .5f).SetEase(Ease.OutBack);   //셋팅창 나타나기
            settingWindow.transform.DOScale(new Vector3(1, 1), .5f).SetEase(Ease.OutBack);   //셋팅창 나타나기
            StartCoroutine(tlqkf());
            //Debug.Log("셋팅창 나타났다 뿅...?");
        }
        StartCoroutine(wait(1));
    }

    void tlqkf2()
    {
        
            Debug.Log("셋팅창 나타났다 뿅...?");
            settingWindow.transform.DOScale(new Vector3(1, 1), .5f).SetEase(Ease.OutBack);   //셋팅창 나타나기

    }

    public void SettingExit()
    {
        Time.timeScale = 1;     //시간 정상으로 되돌리기
        settingWindow.transform.DOScale(new Vector3(0, 0), .5f).SetEase(Ease.InBack);    //셋팅창 사라지기
        StartCoroutine(wait(2));    //셋팅 캔버스의 사라지는 시간은 0.5초 이후에 셋팅창이 사라지는 시간이 0.5초라서
        //Invoke("tlqkf", 0.5f);
    }
    public void RealExit()
    {
        settingCanvas.SetActive(false);
    }

    IEnumerator wait(int oneOrTwo)
    {
        yield return new WaitForSeconds(.5f);   //0.5초 기다리기

        if (oneOrTwo == 1) Time.timeScale = 0;  //0.5초 뒤에 시간을 없에야 창이 똑바로 뜸.
        if (oneOrTwo == 2)
        {
            settingCanvas.SetActive(false);      //셋팅 캔버스의 비활성화는 다 사라진 0.5초 이후에
            settingWindow.transform.localScale = new Vector3(0, 0);
        }
    }

    public void PanelButtonfalse()
    {
        StartCoroutine(False());
    }

    IEnumerator False()
    {
        yield return new WaitForSeconds(0.01f);
        panel.interactable = false;
    }


    IEnumerator tlqkf()
    {
        Debug.Log("tlqkfsettignsoc");
        yield return new WaitForSeconds(0.5f);
        settingWindow.transform.localScale = new Vector3(1f, 1f);

        yield return new WaitForSeconds(0.5f);
        settingWindow.transform.localScale = new Vector3(5f, 5f);

        //settingWindow.GetComponent<RectTransform>().localScale = new Vector3(1, 1);
    }*/
    #endregion

    public void SettingCheck()
    {
        settingCanvas.SetActive(true);
        StartCoroutine(Anim_x(true));
        StartCoroutine(Anim_y(true));
    }

    IEnumerator Anim_x(bool what)
    {
        if (what)
        {
            for (int i = 0; i < 1400; i++)
            {
                yield return new WaitForSeconds(0.00003f);
                settingWindow.GetComponent<RectTransform>().sizeDelta += new Vector2(1, 0);
            }
        }
        else
        {
            for (int i = 0; i < 1400; i++)
            {
                yield return new WaitForSeconds(0.0003f);
                settingWindow.GetComponent<RectTransform>().sizeDelta -= new Vector2(1, 0);
            }

            settingCanvas.SetActive(false);
        }

        yield return null;
    }

    IEnumerator Anim_y(bool what)
    {
        if (what)
        {
            for (int i = 0; i < 800; i++)
            {
                yield return new WaitForSeconds(0.00006f);
                settingWindow.GetComponent<RectTransform>().sizeDelta += new Vector2(0, 1);
            }
        }
        else
        {
            for (int i = 0; i < 800; i++)
            {
                yield return new WaitForSeconds(0.0006f);
                settingWindow.GetComponent<RectTransform>().sizeDelta -= new Vector2(0, 1);
            }
        }

        yield return null;
    }

    public void SettingExit()
    {
        StartCoroutine(Anim_x(false));
        StartCoroutine(Anim_y(false));
    }


}
