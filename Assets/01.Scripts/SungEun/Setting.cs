using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    [SerializeField] GameObject settingCanvas;  //���ð��� ĵ����
    [SerializeField] GameObject settingWindow;     //���� â

    [SerializeField] Button panel = null;

    #region �ù�
    /*private void Awake()
    {
        *//*settingCanvas.transform.localScale = new Vector3(1, 1, 1);
        settingCanvas.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        settingWindow.transform.localScale = new Vector3(1, 1);
        settingWindow.transform.localScale = new Vector3(0, 0);*//*
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //����â�� �� ���� ���� �� ESCŰ�� ������ ��Ÿ���� ��Ÿ�� ���� ���� �������
        {
            if (settingCanvas.activeSelf == true)
            {
                Debug.Log("����â ����");
                SettingExit();
            }
            else if (settingCanvas.activeSelf == false)
            {
                SettingCheck();
                Debug.Log("����â ����");
                if (SceneManager.GetActiveScene().name == "Play")
                {
                    panel.interactable = true;
                }
            }
        }
    }

    public void SettingCheck()
    {
        settingCanvas.SetActive(true);      //���� ĵ���� Ȱ��ȭ
        if (true)
        {
            settingWindow.transform.localScale = new Vector3(0, 0);
            //settingWindow.transform.DOScale(new Vector3(1, 1), .5f).SetEase(Ease.OutBack);   //����â ��Ÿ����
            settingWindow.transform.DOScale(new Vector3(1, 1), .5f).SetEase(Ease.OutBack);   //����â ��Ÿ����
            StartCoroutine(tlqkf());
            //Debug.Log("����â ��Ÿ���� ��...?");
        }
        StartCoroutine(wait(1));
    }

    void tlqkf2()
    {
        
            Debug.Log("����â ��Ÿ���� ��...?");
            settingWindow.transform.DOScale(new Vector3(1, 1), .5f).SetEase(Ease.OutBack);   //����â ��Ÿ����

    }

    public void SettingExit()
    {
        Time.timeScale = 1;     //�ð� �������� �ǵ�����
        settingWindow.transform.DOScale(new Vector3(0, 0), .5f).SetEase(Ease.InBack);    //����â �������
        StartCoroutine(wait(2));    //���� ĵ������ ������� �ð��� 0.5�� ���Ŀ� ����â�� ������� �ð��� 0.5�ʶ�
        //Invoke("tlqkf", 0.5f);
    }
    public void RealExit()
    {
        settingCanvas.SetActive(false);
    }

    IEnumerator wait(int oneOrTwo)
    {
        yield return new WaitForSeconds(.5f);   //0.5�� ��ٸ���

        if (oneOrTwo == 1) Time.timeScale = 0;  //0.5�� �ڿ� �ð��� ������ â�� �ȹٷ� ��.
        if (oneOrTwo == 2)
        {
            settingCanvas.SetActive(false);      //���� ĵ������ ��Ȱ��ȭ�� �� ����� 0.5�� ���Ŀ�
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
