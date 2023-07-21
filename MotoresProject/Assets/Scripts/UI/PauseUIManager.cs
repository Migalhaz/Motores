using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUIManager : MonoBehaviour
{
    public bool m_Paused { get; private set; }
    private void Awake()
    {
        m_Paused = false;
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void PauseInput()
    {
        if (m_Paused)
        {
            Unpause();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        GameManager.Instance.ButtonSFX();
        m_Paused = true;
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        GameManager.Instance.ButtonSFX();
        m_Paused = false;
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        GameManager.Instance.ButtonSFX();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Cena1");
    }
}
