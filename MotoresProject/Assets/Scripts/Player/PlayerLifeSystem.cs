using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeSystem : BasicLifeSystem, IHeal
{
    [SerializeField] Trigger.System2D.BoxTrigger2D m_hitbox;
    [SerializeField] SpriteRenderer m_spriteRenderer;
    bool m_canTakeDamage;
    [SerializeField, Min(0)] float m_invulnerableSeconds;
    [SerializeField, Min(0)] int m_potions = 1;
    [SerializeField] GameObject m_deathParticles;
    public float m_CurrentHp => m_currentHp;
    protected override void Awake()
    {
        base.Awake();
        m_OnHPChange?.Invoke();
        m_canTakeDamage = true;
    }

    private void Update()
    {
        HitBoxCheck();
    }

    void HitBoxCheck()
    {
        AbstractEnemy enemy = m_hitbox.InTrigger<AbstractEnemy>(transform.position, true, false);
        if (enemy is not null)
        {
            Damage(enemy.m_EnemyDamage);
        }
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

    public void DeathEffect()
    {
        Destroy(gameObject);
        Instantiate(m_deathParticles, transform.position, Quaternion.identity);
    }

    IEnumerator DamageEffect()
    {
        for (int i = 0; i < m_invulnerableSeconds * 5f; i++)
        {
            m_spriteRenderer.color = Color.clear;
            yield return new WaitForSeconds(.1f);
            m_spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(.1f);
        }
        m_spriteRenderer.color = Color.white;
        m_canTakeDamage = true;
    }

    private void OnDrawGizmos()
    {
        m_hitbox.DrawTrigger(transform.position);
    }
}
