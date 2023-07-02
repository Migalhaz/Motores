using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Min(0f)] float m_lifeTime;
    [SerializeField,Min(0f)] float m_speed;
    [SerializeField, Min(0f)] float m_bulletDamage;
    Vector3 m_direction;
    [SerializeField] Trigger.System2D.CircleTrigger2D m_collider;

    public void Setup(Vector3 direction)
    {
        m_direction = direction;
        Invoke(nameof(Death), m_lifeTime);
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        Move();
        ColliderCheck();
    }

    void Move()
    {
        transform.Translate(Time.deltaTime * m_speed * m_direction);
    }

    void ColliderCheck()
    {

        GameObject obj = m_collider.InTrigger<GameObject>(transform.position);
        if (obj is not null)
        {
            if (obj.TryGetComponent(out IDieble i))
            {
                i.Damage(m_bulletDamage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        m_collider.DrawTrigger(transform.position);
    }
}
