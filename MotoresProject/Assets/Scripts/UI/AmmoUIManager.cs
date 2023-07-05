using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUIManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI m_textMeshProUGUI;
    public void UpdateAmmoText(float currentAmmo, float maxAmmo)
    {
        m_textMeshProUGUI.text = $"{currentAmmo} / {maxAmmo}";
    }
}
