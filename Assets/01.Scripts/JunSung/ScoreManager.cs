using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance = null;

    private int playerGameScore = 0;
    private int aiGameScore = 0;

    public int PlayerGameScore => playerGameScore;
    public int AIGameScore => aiGameScore;

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
        Mathf.Clamp(playerGameScore += playerScore, 0, 99);
        Mathf.Clamp(aiGameScore += aiScore, 0, 99);

        playerScoreText.text = playerGameScore.ToString();
        aiScoreText.text = aiGameScore.ToString();
    }

    public int CompareScore()
    {
        return playerGameScore - aiGameScore;
    }
}
