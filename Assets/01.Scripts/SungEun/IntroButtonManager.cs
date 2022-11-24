using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroButtonManager : MonoBehaviour
{
    [SerializeField] Button[] panelButton;

    #region play and exit
    public void SceneChange(string sceneName)   //�� �̸��� �Ű� ���� �޾ƿ� �� �� ����
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()  //������
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;    //����Ƽ �����̶�� ���� ����
#else
        Application.Quit();     //�����ؼ� ������ ������? �̶�� ��? ����
#endif
    }
    #endregion

    public void PlaySound()
    {
        SoundManager.Instance.Pop("MP_Tick");
    }

    public void PanelButtonTrue(int panel)      //�̰Ťþ�þ���ġ��ӤӤ�
    {
        panelButton[panel].enabled = true;
    }
    
    public void PanelButtonfalse(int panel)
    {
        panelButton[panel].enabled = false;
    }
}
