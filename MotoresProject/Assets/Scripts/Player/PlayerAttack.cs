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

        Debug.Log(m_playerInputManager.m_LookDirection);
    }
    public void Attack()
    {
        Bullet bullet = Instantiate(m_bullet, m_currentFirePointPosition, Quaternion.identity).GetComponent<Bullet>();
        bullet.Setup(m_playerInputManager.m_LookDirection);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(m_currentFirePointPosition, .1f);
    }
}
