using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInputManager))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] PlayerInputManager m_playerInputManager;
    [SerializeField] Rigidbody2D m_rig;

    [Header("Move Settings")]
    [SerializeField, Min(0)] float m_moveSpeed;

    [Header("Jump Settings")]
    [SerializeField, Min(0)] int m_maxJumps;
    int m_currentJumps;
    [SerializeField, Min(0)] float m_jumpForce;

    [Header("Dash Settings")]
    [SerializeField, Min(0)] float m_dashForce;
    [SerializeField, Min(0)] float m_dashTimer;
    float m_currentDashTimer;

    private void Awake()
    {
        m_rig ??= GetComponent<Rigidbody2D>();
        ResetJumps();
        SetDashTimer(0);
    }
    void Start()
    {
        
    }

    private void Update()
    {
        m_currentDashTimer -= Time.deltaTime;
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //m_rig.velocity = new Vector2((m_moveSpeed * m_playerInputManager.m_MoveDirection.x), m_rig.velocity.y);
        m_rig.AddForce(m_moveSpeed * m_playerInputManager.m_MoveDirection);
    }

    public void Jump()
    {
        if (m_currentJumps <= 0) return;

        m_currentJumps--;
        m_rig.velocity = new Vector2(m_rig.velocity.x, m_jumpForce);
    }

    public void Dash()
    {
        if (m_currentDashTimer > 0) return; 
        //m_rig.velocity = new Vector2(m_dashForce, m_rig.velocity.y);
        m_rig.AddForce(m_playerInputManager.m_LookDirection * m_dashForce, ForceMode2D.Impulse);
        ResetDashTimer();
    }

    public void ResetDashTimer()
    {
        SetDashTimer(m_dashTimer);
    }

    void SetDashTimer(float dashTimer)
    {
        m_currentDashTimer = dashTimer;
    }

    public void ResetJumps()
    {
        SetJumps(m_maxJumps);
    }

    void SetJumps(int jumpCounts)
    {
        m_currentJumps = jumpCounts;
    }
}
