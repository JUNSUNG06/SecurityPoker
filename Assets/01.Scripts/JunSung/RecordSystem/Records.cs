using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Records
{
    /*private int playerScore;
    private int aiScore;
    private int isWin;

    public int PlayerScore => playerScore;
    public int AiScore => aiScore;
    public int IsWin => isWin;

    public Records(int _playerScore, int _aiScore, int _isWin)
    {
        playerScore = _playerScore;
        aiScore = _aiScore;
        isWin = _isWin;
    }*/


    public int playerScore;
    public int aiScore;
    public int isWin;

    public Records(int _playerScore, int _aiScore, int _isWin)
    {
        playerScore = _playerScore;
        aiScore = _aiScore;
        isWin = _isWin;
    }
}
