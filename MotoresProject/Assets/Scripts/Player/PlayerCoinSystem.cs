using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinSystem : MonoBehaviour
{
    AmmoUIManager m_ammoUi;
    int m_coins;

    private void Start()
    {
        m_ammoUi = UIManager.Instance.m_AmmoUIManager;
        m_coins = 0;
    }
    public void AddCoin(int coinValue)
    {
        m_coins+= coinValue;
        UpdateUI();
    }

    void UpdateUI()
    {
        m_ammoUi.UpdateCoinText(m_coins);
    }
}
