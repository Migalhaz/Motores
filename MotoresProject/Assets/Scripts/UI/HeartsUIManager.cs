using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsUIManager : MonoBehaviour
{
    [SerializeField] Sprite m_fullHeart;
    [SerializeField] Sprite m_emptyHeart;
    [SerializeField] List<UnityEngine.UI.Image> m_hearts;
    public void UpdateHearts(PlayerLifeSystem playerLifeSystem)
    {
        float currentHp = playerLifeSystem.m_CurrentHp;
        for (int i = 0; i < m_hearts.Count; i++)
        {
            m_hearts[i].sprite = i + 1 <= currentHp ? m_fullHeart : m_emptyHeart;
        }

    }
}
