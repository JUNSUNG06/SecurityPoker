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


    //��Ʈ��, ����, ȭ�� ����, �� �� ��ü���� �������� �κ�? ��ư�� ��Ʈ �ƴ� ��������Ʈ �־...?
}
