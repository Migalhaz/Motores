using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerVisualController : MonoBehaviour
{
    [SerializeField] PlayerMove m_playerMove;
    [SerializeField] Animator m_anim;
    [SerializeField] SpriteRenderer m_spriteRenderer;

    private void Update()
    {
        SetParameters();
        Flip();
    }

    void SetParameters()
    {
        m_anim.SetBool("Dashing", m_playerMove.IsDashing());
        m_anim.SetBool("Jumping", m_playerMove.IsJumping());
        m_anim.SetBool("Moving", m_playerMove.IsMoving());
    }

    void Flip()
    {
        float lookDirection = PlayerManager.Instance.m_PlayerInputManager.m_LookDirection.x;
        if (lookDirection < 0)
        {
            m_spriteRenderer.flipX = true;
        }
        if (lookDirection > 0)
        {
            m_spriteRenderer.flipX = false;
        }
    }

    public void SetAttackTrigger()
    {
        m_anim.SetTrigger("Attack");
    }

    public void ResetAttackTrigger()
    {
        m_anim.ResetTrigger("Attack");
    }
}
