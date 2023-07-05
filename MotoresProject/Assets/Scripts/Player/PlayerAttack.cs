using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Range m_ammoRange;
    float m_currentAmmo;
    [SerializeField, Min(0)] float m_timeToReload;
    [SerializeField] GameObject m_bullet;
    [SerializeField] PlayerInputManager m_playerInputManager;
    [SerializeField] Vector3 m_firePointPosition;
    Vector3 m_currentFirePointPosition;

    private void Start()
    {
        m_currentAmmo = m_ammoRange.m_MaxValue;
    }

    private void Update()
    {
        m_currentFirePointPosition.Set(
            transform.position.x + m_firePointPosition.x * m_playerInputManager.m_LookDirection.x, 
            transform.position.y + m_firePointPosition.y, 
            transform.position.z + m_firePointPosition.z);

        UIManager.Instance.m_AmmoUIManager.UpdateAmmoText(m_currentAmmo, m_ammoRange.m_MaxValue);
    }
    public void Attack()
    {
        if (m_currentAmmo <= m_ammoRange.m_MinValue) return;
        
        m_currentAmmo--;
        Bullet bullet = Instantiate(m_bullet, m_currentFirePointPosition, Quaternion.identity).GetComponent<Bullet>();
        bullet.Setup(m_playerInputManager.m_LookDirection);
        StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(m_timeToReload);
        m_currentAmmo += m_currentAmmo >= m_ammoRange.m_MaxValue ? 0 : 1;
    }

    private void OnDrawGizmos()
    {
        Vector3 drawPosition = m_currentFirePointPosition;
        drawPosition.x = drawPosition.x == 0 ? transform.position.x + m_firePointPosition.x : drawPosition.x;
        Gizmos.DrawWireSphere(drawPosition, .1f);
    }
}
