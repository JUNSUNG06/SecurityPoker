using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroButtonManager : MonoBehaviour
{
    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    //다트윈, 에셋, 화면 비율, 뭐 더 전체적인 디테일한 부분? 도튼데 도트 아닌 스프라이트 넣어도...?
}
