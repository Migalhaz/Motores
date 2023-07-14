using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeSystem : BasicLifeSystem
{
    [SerializeField] GameObject m_particleSystem;
    [SerializeField] SpriteRenderer m_spriteRenderer;
    [SerializeField, Min(0)] float m_damageEffectTimer;

    public void DamageEffect()
    {
        StartCoroutine(DamageEffectTime());
    }

    IEnumerator DamageEffectTime()
    {
        m_spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(m_damageEffectTimer);
        m_spriteRenderer.color = Color.white;
    }

    public void DeathEffect()
    {
        Instantiate(m_particleSystem, transform.position, Quaternion.identity);
    }

    public override void Death()
    {
        base.Death();
        GameManager.Instance.ExplosionSFX();
        Destroy(gameObject);
    }
}
