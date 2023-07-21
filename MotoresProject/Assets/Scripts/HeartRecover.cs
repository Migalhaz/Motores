using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRecover : MonoBehaviour
{
    PlayerLifeSystem m_playerLifeSystem;
    bool m_forward;
    [SerializeField, Range(0, 10f)] float m_animationSpeed = 2f;
    [SerializeField] Vector3 m_finalPosition;
    Vector3 m_startPosition;
    void Start()
    {
        m_playerLifeSystem = PlayerManager.Instance.m_PlayerLifeSystem;
        m_startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentTarget = m_forward ? m_finalPosition : m_startPosition;
        transform.position = Vector3.Lerp(transform.position, currentTarget, m_animationSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentTarget) <= 1f)
        {
            m_forward = !m_forward;
        }
    }

    public void PickedHeart()
    {
        GameManager.Instance.PowerUpSFX();
        m_playerLifeSystem.Heal();
        gameObject.SetActive(false);
    }
}
