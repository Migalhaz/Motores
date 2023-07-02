using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject m_bullet;
    [SerializeField] PlayerInputManager m_playerInputManager;
    [SerializeField] Vector3 m_firePointPosition;
    Vector3 m_currentFirePointPosition;
    private void Update()
    {
        m_currentFirePointPosition.Set(
            transform.position.x + m_firePointPosition.x * m_playerInputManager.m_LookDirection.x, 
            transform.position.y + m_firePointPosition.y, 
            transform.position.z + m_firePointPosition.z);
    }
    public void Attack()
    {
        Bullet bullet = Instantiate(m_bullet, m_currentFirePointPosition, Quaternion.identity).GetComponent<Bullet>();
        bullet.Setup(m_playerInputManager.m_LookDirection);
    }

    private void OnDrawGizmos()
    {
        Vector3 drawPosition = m_currentFirePointPosition;
        drawPosition.x = drawPosition.x == 0 ? transform.position.x + m_firePointPosition.x : drawPosition.x;
        Gizmos.DrawWireSphere(drawPosition, .1f);
    }
}
