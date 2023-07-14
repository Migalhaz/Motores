using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFlag : Checkpoint
{
    [SerializeField] UnityEngine.Events.UnityEvent OnReachFinalFlag;
    public override void OnTouchFlag()
    {
        OnReachFinalFlag?.Invoke();
    }
}
