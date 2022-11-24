using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Record : MonoBehaviour
{
    [SerializeField] GameObject recordCanvas;
    [SerializeField] GameObject recordWindow;
    //[SerializeField] GameObject ScrollViewHandle;     //�� �ӳ� ���ڵ� â�� ������ �� �ڵ��� ���� ���� �ְ� �ϰ� ����.

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
        recordCanvas.SetActive(true);      //���ڵ� ĵ���� Ȱ��ȭ
        recordWindow.transform.DOScale(new Vector3(1, 1, 1), .5f).SetEase(Ease.OutBack);   //���ڵ�â ��Ÿ����
        //ScrollViewHandle.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);

    }

    public void RecordExit()
    {
        recordWindow.transform.DOScale(new Vector3(0, 0, 0), .5f).SetEase(Ease.InBack);    //���ڵ� �������
        Invoke("RealExit", .5f);    //���ڵ� ĵ������ ������� �ð��� 0.5�� ���Ŀ� ����â�� ������� �ð��� 0.5�ʶ�
    }

    public void RealExit()
    {
        recordCanvas.SetActive(false);     //���ڵ� ĵ���� ��Ȱ��ȭ
        GetComponent<Setting>().enabled = true;
    }
}
