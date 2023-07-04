using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicLifeSystem : MonoBehaviour, IDieble
{
    [SerializeField] Range m_hpRange;
    protected float m_currentHp;
    [SerializeField] protected UnityEvent m_OnHPChange;
    [SerializeField] protected UnityEvent m_OnTakeDamage;
    [SerializeField] protected UnityEvent m_OnHPGotMax;
    [SerializeField] protected UnityEvent m_OnDie;
    protected virtual void Awake()
    {
        m_currentHp = m_hpRange.m_MaxValue;
    }

    public virtual void Damage(float damage)
    {
        
        m_currentHp -= damage;
        if (m_currentHp <= m_hpRange.m_MinValue)
        {
            Death();
        }
        m_OnHPChange?.Invoke();
        m_OnTakeDamage?.Invoke();
    }

    public virtual void Death()
    {
        m_OnDie?.Invoke();
    }
}

public interface IDieble
{
    public void Damage(float damage);
    public void Death();
}

public interface IHeal
{
    public void Heal();
}


[System.Serializable]
public struct Range
{
    [SerializeField] float m_minValue;
    [SerializeField] float m_maxValue;
    public float m_MaxValue => m_maxValue;
    public float m_MinValue => m_minValue;
    public float RandomValue { get { return Random.Range(m_minValue, m_maxValue); } }
    public bool InRange(float value)
    {
        return value >= m_minValue && value <= m_maxValue;
    }
}
