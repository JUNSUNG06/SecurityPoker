using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDifficulty : MonoBehaviour
{
    public GameObject selectCanvas;

    public void ActiveSelectCanvas()
    {
        selectCanvas.SetActive(true);
    }

    public void SetDifficulty(string difficulty)
    {
        PlayerPrefs.SetString("Difficulty", difficulty);
    }
}
