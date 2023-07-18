using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    PlayerManager m_playerManager;
    GameManager m_gameManager;
    private void Start()
    {
        m_playerManager = PlayerManager.Instance;
        m_gameManager = GameManager.Instance;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, m_playerManager.transform.position) < 2f)
        {
            OnTouchFlag();
        }
    }

    public virtual void OnTouchFlag()
    {
        m_gameManager ??= GameManager.Instance;
        if (m_gameManager.m_SpawnPoint != transform)
        {
            m_gameManager.PowerUpSFX();
            m_gameManager.SetCheckpoint(transform);
        }
    }
}
