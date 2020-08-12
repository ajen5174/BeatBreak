using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] string m_gameSceneName = "";
    [SerializeField] string m_levelSelectName = "";
    [SerializeField] GameObject m_instructionPanel = null;

    public void PlayGame()
    {
        PlayerPrefs.SetInt("levelToLoad", 0);

        SceneManager.LoadScene(m_gameSceneName);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(m_levelSelectName);
    }

    public void Instructions()
    {
        if(m_instructionPanel != null)
        {
            Instantiate(m_instructionPanel, gameObject.transform);
        }
    }

    public void ExitInstructions()
    {
        Destroy(gameObject);
    }


}
