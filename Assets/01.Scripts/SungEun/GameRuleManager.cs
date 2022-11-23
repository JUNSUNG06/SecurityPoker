using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRuleManager : MonoBehaviour
{
    [SerializeField] GameObject[] gameRulePage;
    [SerializeField] GameObject rightArrow;
    [SerializeField] GameObject leftArrow;

    [SerializeField] GameObject[] pagePoint;
    [SerializeField] GameObject pagePointPosition;

    int nowPage = 0;

    private void Update()
    {
        if (nowPage == 0)
        {
            leftArrow.SetActive(false);
        }
        else
        {
            leftArrow.SetActive(true);
        }

        if (nowPage == gameRulePage.Length - 1)
        {
            rightArrow.SetActive(false);
        }
        else
        {
            rightArrow.SetActive(true);
        }
    }

    public void RightPage()
    {
        if (nowPage < gameRulePage.Length - 1)
        {
            nowPage++;
        }

        gameRulePage[nowPage].SetActive(true);

        for (int i = 0; i < gameRulePage.Length; i++)
        {
            if (gameRulePage[i] != gameRulePage[nowPage])
            {
                gameRulePage[i].SetActive(false);
            }
        }

        pagePointPosition.transform.position = pagePoint[nowPage].transform.position;
    }

    public void LeftPage()
    {
        if (nowPage > 0)
        {
            nowPage--;
        }

        gameRulePage[nowPage].SetActive(true);

        for (int i = 0; i < gameRulePage.Length; i++)
        {
            if (gameRulePage[i] != gameRulePage[nowPage])
            {
                gameRulePage[i].SetActive(false);
            }
        }

        pagePointPosition.transform.position = pagePoint[nowPage].transform.position;
    }
}
