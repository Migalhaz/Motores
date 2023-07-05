using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUIManager : MonoBehaviour
{
    [SerializeField] GameObject m_gameOverUIPanel;
    [SerializeField] GameObject m_gameUI;
    [SerializeField, Min(0)] private float m_timeToGameOverScreen =1f;

    private void Awake()
    {
        m_gameOverUIPanel.SetActive(false);
    }

    void ActiveGameOverUI()
    {
        m_gameOverUIPanel.SetActive(true);
        m_gameUI.SetActive(false);
    }
    
    public void OnPlayerDeath()
    {
        Invoke(nameof(ActiveGameOverUI), m_timeToGameOverScreen);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Debug.LogWarning("Função 'Menu' não implementada! Script DeathUIManager");
    }

    public void Quit()
    {
        Application.Quit();
    }
}