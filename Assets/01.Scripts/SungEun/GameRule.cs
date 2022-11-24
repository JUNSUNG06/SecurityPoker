using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameRule : MonoBehaviour
{
    [SerializeField] GameObject gameRuleCanvas;  //���ӷ���� ĵ����
    [SerializeField] GameObject gameRuleWindow;     //���ӷ� â

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //���ӷ�â�� �� ���� ���� �� ESCŰ�� ������ ��Ÿ���� ��Ÿ�� ���� ���� �������
        {
            if (gameRuleCanvas.activeSelf == true)
            {
                GameRuleExit();
            }
        }

    }

    public void GameRuleCheck()
    {
        gameRuleCanvas.SetActive(true);      //���ӷ� ĵ���� Ȱ��ȭ
        gameRuleWindow.transform.DOScale(new Vector3(1, 1, 1), .5f).SetEase(Ease.OutBack);   //���ӷ�â ��Ÿ����
        StartCoroutine(wait(1));
    }

    public void GameRuleExit()
    {
        Time.timeScale = 1;     //�ð� �������� �ǵ�����
        gameRuleWindow.transform.DOScale(new Vector3(0, 0, 0), .5f).SetEase(Ease.InBack);    //���ӷ�â �������
        StartCoroutine(wait(2));    //���ӷ� ĵ������ ������� �ð��� 0.5�� ���Ŀ� ����â�� ������� �ð��� 0.5�ʶ�
    }

    IEnumerator wait(int oneOrTwo)
    {
        yield return new WaitForSeconds(.5f);   //0.5�� ��ٸ���

        if (oneOrTwo == 1) Time.timeScale = 0;  //0.5�� �ڿ� �ð��� ������ â�� �ȹٷ� ��.
        if (oneOrTwo == 2) gameRuleCanvas.SetActive(false);      //���� ĵ������ ��Ȱ��ȭ�� �� ����� 0.5�� ���Ŀ�
    }
}
