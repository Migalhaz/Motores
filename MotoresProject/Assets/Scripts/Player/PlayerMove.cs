using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInputManager))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] PlayerInputManager m_playerInputManager;
    [SerializeField] Rigidbody2D m_rig;
    [SerializeField] PhysicsController m_physicsController;

    [Header("Move Settings")]
    [SerializeField, Min(0)] float m_moveSpeed;

    [Header("Jump Settings")]
    bool m_jumping;
    [SerializeField, Min(0)] int m_maxJumps;
    int m_currentJumps;
    [SerializeField, Min(0)] float m_jumpForce;

    [Header("Dash Settings")]
    bool m_dashing;
    [SerializeField, Min(0)] float m_dashForce;
    [SerializeField, Min(0)] float m_dashCooldown;
    float m_currentDashCooldown;
    [SerializeField, Min(0)] float m_dashTimer;

    private void Awake()
    {
        m_rig ??= GetComponent<Rigidbody2D>();
        SetJumps(0);
        SetDashTimer(1f);
        m_dashing = false;
    }

    public bool IsDashing()
    {
        return m_dashing;
    }

    public bool IsJumping()
    {
        return m_jumping;
    }

    public bool IsMoving()
    {
        return m_playerInputManager.m_MoveDirection.x != 0;
    }

    private void Update()
    {
        m_currentDashCooldown -= Time.deltaTime;
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (m_dashing) return;
        m_rig.velocity = new Vector2(m_moveSpeed * m_playerInputManager.m_MoveDirection.x, m_rig.velocity.y);
    }

    public void Jump()
    {
        if (m_dashing) return;
        if (m_currentJumps <= 0) return;
        DecreaseJump();
        m_rig.velocity = Vector2.up * m_jumpForce;
    }

    public void DecreaseJump()
    {
        m_currentJumps--;
    }

    public void SetJumping(bool jumping)
    {
        m_jumping = jumping;
    }

    public void Dash()
    {
        if (m_dashing) return;
        if (m_currentDashCooldown > 0) return;
        m_physicsController.SetGravity(0);
        m_dashing = true;
        StartCoroutine(Dashing());
        ResetDashTimer();
    }

    IEnumerator Dashing()
    {
        m_rig.velocity = m_playerInputManager.m_LookDirection * m_dashForce;
        yield return new WaitForSeconds(m_dashTimer);
        m_dashing = false;
        m_physicsController.SetGravity(m_physicsController.m_defaultGravityValue);
    }

    public void ResetDashTimer()
    {
        SetDashTimer(m_dashCooldown);
    }

    void SetDashTimer(float dashTimer)
    {
        m_currentDashCooldown = dashTimer;
    }

    public void ResetJumps()
    {
        SetJumps(m_maxJumps);
    }

    void SetJumps(int jumpCounts)
    {
        m_currentJumps = jumpCounts;
    }

    public void IncreaseMaxJump()
    {
        m_maxJumps++;
    }
}
