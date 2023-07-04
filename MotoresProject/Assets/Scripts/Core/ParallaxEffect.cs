using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    float m_length;
    float m_startPos;
    Transform m_camTransform;
    [SerializeField, Range(0f, 2f)] float m_parallaxEffectMultiplier;
    Vector3 m_currentPosition;
    void Start()
    {
        m_startPos = transform.position.x;
        m_length = GetComponent<SpriteRenderer>().bounds.size.x;
        m_camTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Parallax();
    }

    void Parallax()
    {
        float restartPos = m_camTransform.position.x * (1 - m_parallaxEffectMultiplier);
        float distance = m_camTransform.position.x * m_parallaxEffectMultiplier;
        m_currentPosition.Set(m_startPos + distance, transform.position.y, transform.position.z);
        transform.position = m_currentPosition;
        if (restartPos > m_startPos + m_length)
        {
            m_startPos += m_length;
        }
        if (restartPos < m_startPos - m_length)
        {
            m_startPos -= m_length;
        }
    }
}
