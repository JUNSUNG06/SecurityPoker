using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Record : MonoBehaviour
{
    [SerializeField] GameObject recordCanvas;
    [SerializeField] GameObject recordWindow;
    //[SerializeField] GameObject ScrollViewHandle;     //그 머냐 리코드 창을 눌렀을 때 핸들이 가장 위에 있게 하고 싶음.

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //리코드창이 켜져 있을 때 ESC키를 누르면 사라짐.
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
        recordCanvas.SetActive(true);      //리코드 캔버스 활성화
        recordWindow.transform.DOScale(new Vector3(1, 1, 1), .5f).SetEase(Ease.OutBack);   //리코드창 나타나기
        //ScrollViewHandle.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);

    }

    public void RecordExit()
    {
        recordWindow.transform.DOScale(new Vector3(0, 0, 0), .5f).SetEase(Ease.InBack);    //리코드 사라지기
        Invoke("RealExit", .5f);    //리코드 캔버스의 사라지는 시간은 0.5초 이후에 셋팅창이 사라지는 시간이 0.5초라서
    }

    public void RealExit()
    {
        recordCanvas.SetActive(false);     //리코드 캔버스 비활성화
        GetComponent<Setting>().enabled = true;
    }
}
