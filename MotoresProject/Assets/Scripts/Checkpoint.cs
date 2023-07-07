using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    PlayerManager m_playerManager;
    private void Start()
    {
        m_playerManager = PlayerManager.Instance;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, m_playerManager.transform.position) < 2f)
        {
            GameManager.Instance.SetCheckpoint(transform);
        }
    }
}
