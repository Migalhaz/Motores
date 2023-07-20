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
        Setup();
    }

    private void Update()
    {
        HitBoxCheck();
    }

    public void Setup()
    {
        m_currentHp = m_hpRange.m_MaxValue;
        m_OnHPChange?.Invoke();
        m_canTakeDamage = true;
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
        StartCoroutine(DamageEffect());
        base.Damage(damage);
        m_canTakeDamage = false;
    }

    public void DeathEffect()
    {
        GameManager.Instance.ExplosionSFX();
        UIManager.Instance.m_GameOverUIManager.RestartButton(false);
        Instantiate(m_deathParticles, transform.position, Quaternion.identity);
        StopAllCoroutines();
        m_spriteRenderer.color = Color.white;
        gameObject.SetActive(false);
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
