using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI resultText;

    private int resultValue = 0;

    public void LoadIntroScene()
    {
        RecordManager.instance.CreateRecord(ScoreManager.Instance.PlayerGameScore, ScoreManager.Instance.AIGameScore, resultValue, true);
        SoundManager.Instance.Pop("MP_Tick");
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
            resultText.text = "Win";
            resultValue = 1;
        }
        if (scoreDiff < 0)
        {
            resultText.color = Color.blue;
            resultText.text = "Lose";
            resultValue = 2;
        }
        if (scoreDiff == 0)
        {
            resultText.color = Color.gray;
            resultText.text = "Draw";
            resultValue = 3;
        }
        
        scoreText.text = $"{ScoreManager.Instance.PlayerGameScore} : {ScoreManager.Instance.AIGameScore}";
    }
}
