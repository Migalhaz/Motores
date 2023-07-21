using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUIManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI m_ammoText;
    [SerializeField] TMPro.TextMeshProUGUI m_coinText;
    public void UpdateAmmoText(float currentAmmo, float maxAmmo)
    {
        m_ammoText.text = $"{currentAmmo} / {maxAmmo}";
    }

    public void UpdateCoinText(float coins)
    {
        m_coinText.text = coins.ToString("000");
    }
}
