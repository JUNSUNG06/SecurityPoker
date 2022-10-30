using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Setting : MonoBehaviour
{
    [SerializeField] GameObject settingCanvas;  //���ð��� ĵ����
    [SerializeField] GameObject settingWindow;     //���� â

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //����â�� �� ���� ���� �� ESCŰ�� ������ ��Ÿ���� ��Ÿ�� ���� ���� �������
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
        settingCanvas.SetActive(true);      //���� ĵ���� Ȱ��ȭ
        settingWindow.transform.DOScale(new Vector3(1, 1, 1), .5f).SetEase(Ease.OutBack);   //����â ��Ÿ����
        StartCoroutine(wait(1));
    }

    public void SettingExit()
    {
        Time.timeScale = 1;     //�ð� �������� �ǵ�����
        settingWindow.transform.DOScale(new Vector3(0, 0, 0), .5f).SetEase(Ease.InBack);    //����â �������
        StartCoroutine(wait(2));    //���� ĵ������ ������� �ð��� 0.5�� ���Ŀ� ����â�� ������� �ð��� 0.5�ʶ�
    }

    IEnumerator wait(int oneOrTwo)
    {
        yield return new WaitForSeconds(.5f);   //0.5�� ��ٸ���

        if (oneOrTwo == 1) Time.timeScale = 0;  //0.5�� �ڿ� �ð��� ������ â�� �ȹٷ� ��.
        if (oneOrTwo == 2) settingCanvas.SetActive(false);      //���� ĵ������ ��Ȱ��ȭ�� �� ����� 0.5�� ���Ŀ�
    }
}
