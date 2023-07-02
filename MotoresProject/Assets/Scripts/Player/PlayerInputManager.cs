using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputManager : MonoBehaviour
{
    Vector2 m_moveDirection;
    Vector2 m_lookDirection;
    public Vector2 m_MoveDirection => m_moveDirection;
    public Vector2 m_LookDirection => m_lookDirection;
    [Header("Jump Inputs")]
    [SerializeField] KeyCode m_jumpKey;
    [SerializeField] UnityEvent OnJumpKeyPressed;

    [Header("Dash Inputs")]
    [SerializeField] KeyCode m_dashKey;
    [SerializeField] UnityEvent OnDashKeyPressed;

    [Header("Attack Inputs")]
    [SerializeField] KeyCode m_attackKey;
    [SerializeField] UnityEvent OnAttackKeyPressed;

    private void Awake()
    {
        m_lookDirection = Vector2.right;
    }

    public void Update()
    {
        m_moveDirection.Set(Input.GetAxisRaw("Horizontal"), 0f);
        m_lookDirection = m_moveDirection.x != 0 ? m_moveDirection : m_lookDirection;

        if (Input.GetKeyDown(m_jumpKey))
        {
            OnJumpKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(m_dashKey))
        {
            OnDashKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(m_attackKey))
        {
            OnAttackKeyPressed?.Invoke();
        }
    }
}
