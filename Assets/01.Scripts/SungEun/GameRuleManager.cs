using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRuleManager : MonoBehaviour
{
    [SerializeField] GameObject[] gameRulePage;
    [SerializeField] GameObject rightArrow;
    [SerializeField] GameObject leftArrow;

    int nowPage = 0;

    private void Update()
    {
        if (nowPage == 0)
        {
            rightArrow.SetActive(false);
        }
        if (nowPage == gameRulePage.Length - 1)
        {
            leftArrow.SetActive(false);
        }
    }

    public void RightPage()
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
    }

    public void LeftPage()
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
    }
}
