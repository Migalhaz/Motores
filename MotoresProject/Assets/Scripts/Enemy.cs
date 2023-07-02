using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Trigger.System2D.BoxTrigger2D), typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField, Min(0)] float m_enemySpeed;
    float m_direction;
    private void Start()
    {
        m_direction = Random.value > .5f ? 1f : -1f;
    }
    private void Update()
    {
        transform.Translate(m_direction * m_enemySpeed * Time.deltaTime * Vector2.right);
    }

    public void FlipLeft()
    {
        m_direction = -1f;
    }

    public void FlipRight()
    {
        m_direction = 1f;
    }
}
