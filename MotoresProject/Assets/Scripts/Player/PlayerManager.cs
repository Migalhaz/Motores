using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] PlayerLifeSystem m_playerLifeSystem;
    [SerializeField] PlayerInputManager m_playerInputManager;
    [SerializeField] PlayerMove m_playerMove;

    public PlayerLifeSystem m_PlayerLifeSystem => m_playerLifeSystem;
    public PlayerInputManager m_PlayerInputManager => m_playerInputManager;
    public PlayerMove m_PlayerMove => m_playerMove;
}
