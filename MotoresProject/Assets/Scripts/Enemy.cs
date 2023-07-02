using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField, Min(0)] float m_enemySpeed;
    [SerializeField] Trigger.System2D.BoxTrigger2D m_collider;
    float m_direction;
    private void Start()
    {
        m_direction = Random.value > .5f ? 1f : -1f;
    }
    private void Update()
    {
        Move();
        ColliderCheck();
    }

    void Move()
    {
        transform.Translate(m_direction * m_enemySpeed * Time.deltaTime * Vector2.right);
    }

    void ColliderCheck()
    {
        PlayerLifeSystem playerLife = m_collider.InTrigger<PlayerLifeSystem>(transform.position);

        if (playerLife is not null)
        {
            playerLife.Damage(1f);
        }
    }

    public void FlipLeft()
    {
        m_direction = -1f;
    }

    public void FlipRight()
    {
        m_direction = 1f;
    }

    private void OnDrawGizmos()
    {
        m_collider.DrawTrigger(transform.position);
    }
}
