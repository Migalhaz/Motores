using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField, Min(1)] int m_coinValue = 1;
    PlayerCoinSystem m_playerCoinSystem;
    void Start()
    {
        transform.parent = null;
        m_playerCoinSystem = PlayerManager.Instance.m_PlayerCoinSystem;
    }
    public void PickedCoin()
    {
        GameManager.Instance.PowerUpSFX();
        m_playerCoinSystem.AddCoin(m_coinValue);
        gameObject.SetActive(false);
    }
}
