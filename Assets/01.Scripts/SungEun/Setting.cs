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

    bool cilck;

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
            }
        }
    }

    public void SettingCheck()
    {
        panel.interactable = true;

        settingCanvas.SetActive(true);
        settingWindow.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.OutBack);   //����â ��Ÿ����

        cilck = true;

        StartCoroutine(wait(1));
    }

    public void SettingExit()
    {
        cilck = false;

        if (SceneManager.GetActiveScene().name == "Play")
        {
            Time.timeScale = 1;     //�ð� �������� �ǵ�����
            Debug.Log("�ð��� ������!");
        }
        settingWindow.transform.DOScale(new Vector3(0, 0, 0), .5f).SetEase(Ease.InBack);    //����â �������
        StartCoroutine(wait(2));    //���� ĵ������ ������� �ð��� 0.5�� ���Ŀ� ����â�� ������� �ð��� 0.5�ʶ�
        //Invoke("tlqkf", 0.5f);
        panel.interactable = false;
    }

    IEnumerator wait(int oneOrTwo)
    {
        yield return new WaitForSeconds(.5f);   //0.5�� ��ٸ���

        if (oneOrTwo == 1 && cilck == true) 
        {
            if (SceneManager.GetActiveScene().name == "Play")
            {
                Time.timeScale = 0;
                Debug.Log("�ð��� �����!");
            }
        }  
        if (oneOrTwo == 2)
        {
            settingCanvas.SetActive(false);
        }
    }

}
