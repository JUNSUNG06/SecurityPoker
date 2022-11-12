using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI scoreText;

    public void LoadIntroScene()
    {
        SceneManager.LoadScene("Intro");
    }

    public void ShowEndPanel()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);        
        }

        if (ScoreManager.Instance.CompareScore() > 0)
        {
            resultText.color = Color.red;
            resultText.text = "Win";
        }
        else if (ScoreManager.Instance.CompareScore() < 0)
        {
            resultText.color = Color.blue;
            resultText.text = "Lose";
        }
        else
        {
            resultText.color = Color.gray;
            resultText.text = "Draw";
        }

        scoreText.text = $"{ScoreManager.Instance.PlayerGameScore} : {ScoreManager.Instance.AIGameScore}";
    }
}
