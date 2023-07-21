using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] HeartsUIManager m_heartsUIManager;
    [SerializeField] AmmoUIManager m_ammoUIManager;
    [SerializeField] DeathUIManager m_gameOverUIManager;
    [SerializeField] PauseUIManager m_pauseUIManager;

    public HeartsUIManager m_HeartsUIManager => m_heartsUIManager;
    public AmmoUIManager m_AmmoUIManager => m_ammoUIManager;
    public DeathUIManager m_GameOverUIManager => m_gameOverUIManager;
    public PauseUIManager m_PauseUIManager => m_pauseUIManager;
}
