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
    PlayerVisualController m_playerVisualController;
    PlayerMove m_playerMove;

    private void Awake()
    {
        m_playerMove = GetComponent<PlayerMove>();
        m_playerVisualController = GetComponent<PlayerVisualController>();
    }

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
        if (m_playerMove.IsDashing()) return;
        if (m_currentAmmo <= m_ammoRange.m_MinValue) return;
        m_playerVisualController.SetAttackTrigger();
        m_currentAmmo--;
        Bullet bullet = Instantiate(m_bullet, m_currentFirePointPosition, Quaternion.identity).GetComponent<Bullet>();
        bullet.Setup(m_playerInputManager.m_LookDirection);
        StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        yield return null;
        m_playerVisualController.ResetAttackTrigger();
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
