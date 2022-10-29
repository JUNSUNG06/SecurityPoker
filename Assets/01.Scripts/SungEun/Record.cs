using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Record : MonoBehaviour
{
    [SerializeField] GameObject recordCanvas;  //���ð��� ĵ����
    [SerializeField] GameObject recordWindow;     //���� â

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //���ڵ�â�� ���� ���� �� ESCŰ�� ������ �����.
        {
            if (recordCanvas.activeSelf == true)
            {
                RecordExit();
            }
        }

    }

    public void RecordCheck()
    {
        GetComponent<Setting>().enabled = false;
        recordCanvas.SetActive(true);      //���� ĵ���� Ȱ��ȭ
        recordWindow.transform.DOScale(new Vector3(1, 1, 1), .5f).SetEase(Ease.OutBack);   //����â ��Ÿ����
    }

    public void RecordExit()
    {
        recordWindow.transform.DOScale(new Vector3(0, 0, 0), .5f).SetEase(Ease.InBack);    //����â �������
        Invoke("RealExit", .5f);    //���� ĵ������ ������� �ð��� 0.5�� ���Ŀ� ����â�� ������� �ð��� 0.5�ʶ�
    }

    void RealExit()
    {
        recordCanvas.SetActive(false);     //���� ĵ���� ��Ȱ��ȭ
        GetComponent<Setting>().enabled = true;
    }
}
