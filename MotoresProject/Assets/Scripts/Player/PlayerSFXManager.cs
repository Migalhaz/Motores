using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFXManager : MonoBehaviour
{
    PlayerMove m_playerMove;
    [SerializeField] AudioSource m_jumpAudioSource;
    [SerializeField] AudioSource m_fireAudioSource;
    [SerializeField] AudioSource m_footstepsAudioSources;
    [SerializeField] AudioSource m_damageAudioSources;

    private void Start()
    {
        m_playerMove = PlayerManager.Instance.m_PlayerMove;
    }
    private void Update()
    {
        if (m_playerMove.IsJumping())
        {
            StopMoveSFX();
            return;
        }

        if (!m_playerMove.IsMoving())
        {
            StopMoveSFX();
            return;
        }

        if (m_footstepsAudioSources.isPlaying) return;
        m_footstepsAudioSources?.Play();
    }

    void StopMoveSFX()
    {
        m_footstepsAudioSources?.Stop();
    }
    public void JumpSfx()
    {
        m_jumpAudioSource?.Play();
    }

    public void ShootSFX()
    {
        m_fireAudioSource?.Play();
    }

    public void DamageSfx()
    {
        m_damageAudioSources?.Play();
    }
}
