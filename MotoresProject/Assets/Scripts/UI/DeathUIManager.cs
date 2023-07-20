using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUIManager : MonoBehaviour
{
    [SerializeField] GameObject m_gameOverUIPanel;
    [SerializeField] GameObject m_gameUI;
    [SerializeField, Min(0)] private float m_timeToGameOverScreen = 1f;
    [SerializeField] GameObject m_buttonPlayAgain;
    [SerializeField] GameObject m_buttonRestart;

    public bool m_GameOver { get; private set; }

    private void Awake()
    {
        m_GameOver = false;
        m_gameOverUIPanel.SetActive(false);
    }

    void ActiveGameOverUI()
    {
        m_GameOver = true;
        m_gameOverUIPanel.SetActive(true);
        m_gameUI.SetActive(false);
    }
    
    public void OnPlayerDeath()
    {
        Invoke(nameof(ActiveGameOverUI), m_timeToGameOverScreen);
    }
    public void InstaGameOver()
    {
        ActiveGameOverUI();
    }

    public void RestartButton(bool restartScene)
    {
        if (restartScene)
        {
            m_buttonPlayAgain.SetActive(true);
            m_buttonRestart.SetActive(false);
        }
        else
        {
            m_buttonPlayAgain.SetActive(false);
            m_buttonRestart.SetActive(true);
        }
    }

    public void Restart()
    {
        m_GameOver = false;
        GameManager.Instance.ButtonSFX();
        m_gameOverUIPanel.SetActive(false);
        m_gameUI.SetActive(true);
        GameManager.Instance.SetupScene();
    }

    public void WinRestart()
    {
        m_GameOver = false;
        GameManager.Instance.ButtonSFX();
        m_gameOverUIPanel.SetActive(false);
        m_gameUI.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        GameManager.Instance.ButtonSFX();
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        GameManager.Instance.ButtonSFX();
        Application.Quit();
    }
}