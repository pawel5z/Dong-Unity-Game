using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LengthEffectCarrierBehaviour : EffectCarrierBehaviour
{
    public float lengthMult;

    private Vector3 defaultPlayerScale;
    private Transform parentTransform;

    // Start is called before the first frame update
    void Start()
    {
        parentTransform = transform.parent.gameObject.GetComponent<Transform>();
        defaultPlayerScale = parentTransform.localScale;
        parentTransform.localScale = new Vector3(defaultPlayerScale.x, defaultPlayerScale.y * lengthMult, defaultPlayerScale.z);
        Destroy(gameObject, effectDuration);
    }

    private void OnDestroy()
    {
        parentTransform.localScale = defaultPlayerScale;
    }
}
