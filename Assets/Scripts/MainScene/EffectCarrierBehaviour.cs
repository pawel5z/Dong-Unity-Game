using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectCarrierBehaviour : MonoBehaviour
{
    public float effectDuration;

    protected abstract void OnDestroy();
}
