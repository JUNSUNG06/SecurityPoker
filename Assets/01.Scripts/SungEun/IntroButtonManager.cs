using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroButtonManager : MonoBehaviour
{
    [SerializeField] Button[] panelButton;

    #region play and exit
    public void SceneChange(string sceneName)   //씬 이름을 매개 변수 받아와 그 씬 번경
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()  //나가기
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;    //유니티 엔진이라면 엔진 종료
#else
        Application.Quit();     //빌드해서 게임이 앱형식? 이라면 앱? 종료
#endif
    }
    #endregion

    public void PlaySound()
    {
        SoundManager.Instance.Pop("MP_Tick");
    }

    public void PanelButtonTrue(int panel)      //이거ㅓ어ㅓ어어고치기ㅣㅣㅣ
    {
        panelButton[panel].enabled = true;
    }
    
    public void PanelButtonfalse(int panel)
    {
        panelButton[panel].enabled = false;
    }
}
