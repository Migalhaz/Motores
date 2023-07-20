using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFlag : Checkpoint
{
    [SerializeField, Range(0f, 1f)] float m_endEffectSmothness = .5f;
    [SerializeField, Range(0f, 1f)] float m_endEffectLimit = .2f;
    [SerializeField] UnityEngine.Events.UnityEvent OnReachFinalFlag;
    bool m_touched;

    public override void OnTouchFlag()
    {
        if (m_touched) return;
        SetTouch(true);
        UIManager.Instance.m_GameOverUIManager.RestartButton(true);
        GameManager.Instance.PowerUpSFX();
        EndEffect();
    }

    void EndEffect()
    {
        StartCoroutine(nameof(TimeScaleEffect));
    }

    IEnumerator TimeScaleEffect()
    {
        Time.timeScale = Mathf.Lerp(Time.timeScale, 0f, m_endEffectSmothness);
        yield return new WaitForSeconds(0.1f);
        if (Time.timeScale <= m_endEffectLimit)
        {
            OnReachFinalFlag?.Invoke();
            Time.timeScale = 0f;
        }
        else
        {
            EndEffect();
        }
    }

    public void SetTouch(bool touched)
    {
        m_touched = touched;
    }
}
