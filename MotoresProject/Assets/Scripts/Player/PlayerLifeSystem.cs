using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeSystem : BasicLifeSystem, IHeal
{
    [SerializeField, Min(0)] int m_potions = 1;
    public void Heal()
    {
        if (m_potions <= 0) return;
        m_potions--;
        m_currentHp++;
    }
}
