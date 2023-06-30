using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInputManager))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] PlayerInputManager m_playerInputManager;
    [SerializeField] Rigidbody2D m_rig;

    [SerializeField] float m_moveSpeed;
    [SerializeField] float m_jumpForce;

    private void Awake()
    {
        m_rig ??= GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        m_rig.AddForce(m_moveSpeed * Time.fixedDeltaTime * m_playerInputManager.m_MoveDirection, ForceMode2D.Impulse);
    }

    public void Jump()
    {
        m_rig.velocity = new Vector2(m_rig.velocity.x, m_rig.velocity.y + m_jumpForce);
    }
}
