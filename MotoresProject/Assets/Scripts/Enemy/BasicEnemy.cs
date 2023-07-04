using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class BasicEnemy : AbstractEnemy
{
    [SerializeField, Min(0)] float m_enemySpeed;
    float m_direction;
    private void Start()
    {
        m_direction = Random.value > .5f ? 1f : -1f;
    }
    private void Update()
    {
        Move();
    }

    void Move()
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

public abstract class AbstractEnemy : MonoBehaviour
{
    [SerializeField, Min(0)] float m_enemyDamage;

    public float m_EnemyDamage => m_enemyDamage;
}