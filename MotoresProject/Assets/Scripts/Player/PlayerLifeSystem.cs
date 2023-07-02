using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeSystem : BasicLifeSystem, IHeal
{
    [SerializeField] SpriteRenderer m_spriteRenderer;
    bool m_canTakeDamage;
    [SerializeField, Min(0)] float m_invulnerableSeconds;
    [SerializeField, Min(0)] int m_potions = 1;
    protected override void Awake()
    {
        base.Awake();
        m_canTakeDamage = true;
    }
    public void Heal()
    {
        if (m_potions <= 0) return;
        m_potions--;
        m_currentHp++;
    }

    public override void Damage(float damage)
    {
        if (!m_canTakeDamage) return;
        base.Damage(damage);
        m_canTakeDamage = false;
        StartCoroutine(DamageEffect());
    }

    IEnumerator DamageEffect()
    {
        m_spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(m_invulnerableSeconds);
        m_spriteRenderer.color = Color.white;
        m_canTakeDamage = true;
    }
}
