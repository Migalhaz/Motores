using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsController : MonoBehaviour
{
    [SerializeField] Rigidbody2D m_rig;
    public float m_defaultGravityValue { get; private set; }
    public float m_defaultDragValue { get; private set; }

    public void Awake()
    {
        m_defaultGravityValue = m_rig.gravityScale;
        m_defaultDragValue = m_rig.drag;
    }

    public void SetPhysicsSettings(PhysicSettings newPhysicSettings)
    {
        SetGravity(newPhysicSettings.m_GravityValue);
        SetLinearDrag(newPhysicSettings.m_DragValue);
    }

    public void SetLinearDrag(float value)
    {
        m_rig.drag = value;
    }

    public void SetGravity(float value)
    {
        m_rig.gravityScale = value;
    }
}

[System.Serializable]
public struct PhysicSettings
{
    [SerializeField] float m_gravityValue;
    [SerializeField] float m_dragValue;

    public float m_GravityValue => m_gravityValue;
    public float m_DragValue => m_dragValue;
}
