using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Records
{
    private int playerScore;
    private int aiScore;
    private bool isWin;

    public int PlayerScore => playerScore;
    public int AiScore => aiScore;
    public bool IsWin => isWin;

    public Records(int _playerScore, int _aiScore, bool _isWin)
    {
        playerScore = _playerScore;
        aiScore = _aiScore;
        isWin = _isWin;
    }
}
