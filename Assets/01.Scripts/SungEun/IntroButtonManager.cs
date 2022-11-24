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
        panelButton[panel].interactable = true;
    }
    
    public void PanelButtonfalse(int panel)
    {
        StartCoroutine(False(panel));
    }

    IEnumerator False(int panel)
    {
        yield return new WaitForSeconds(0.01f);
        panelButton[panel].interactable = false;        //interactable�� ��ư�� Ȱ��ȭ, ��Ȱ��ȭ�� enabled�� ������Ʈ�� Ȱ��ȭ, ��Ȱ��ȭ��.
    }
}
