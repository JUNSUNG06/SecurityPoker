using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI resultText;

    public void LoadIntroScene()
    {
        SceneManager.LoadScene("Intro");
    }

    public void ShowEndPanel()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

        int scoreDiff = ScoreManager.Instance.CompareScore();

        if(scoreDiff > 0)
        {
            resultText.color = Color.red;
            scoreText.text = "Win";
        }
        if (scoreDiff < 0)
        {
            resultText.color = Color.blue;
            scoreText.text = "Lose";
        }
        if (scoreDiff == 0)
        {
            resultText.color = Color.gray;
            scoreText.text = "Draw";
        }
        
        scoreText.text = $"{ScoreManager.Instance.PlayerGameScore} : {ScoreManager.Instance.AIGameScore}";
    }
}
