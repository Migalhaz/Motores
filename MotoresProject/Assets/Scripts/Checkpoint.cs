using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    PlayerManager m_playerManager;
    GameManager m_gameManager;
    [SerializeField] float m_flagTouchDistance = 2f;
    private void Start()
    {
        m_playerManager = PlayerManager.Instance;
        m_gameManager = GameManager.Instance;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, m_playerManager.transform.position) < m_flagTouchDistance)
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, m_flagTouchDistance);
    }
}
