using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance = null;

    private int playerGameScore = 0;
    private int aiGameScore = 0;

    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI aiScoreText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

    }

    public void AddGameScore(int playerScore, int aiScore)
    {
        playerGameScore += playerScore;
        aiGameScore += aiScore;

        playerScoreText.text = playerGameScore.ToString();
        aiScoreText.text = aiGameScore.ToString();
    }
}
