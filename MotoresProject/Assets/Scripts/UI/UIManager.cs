using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] HeartsUIManager m_heartsUIManager;
    [SerializeField] AmmoUIManager m_ammoUIManager;

    public HeartsUIManager m_HeartsUIManager => m_heartsUIManager;
    public AmmoUIManager m_AmmoUIManager => m_ammoUIManager;
}
