using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEffectCarrierBehaviour : EffectCarrierBehaviour
{
    public float speedMult;
    private float playerDefaultSpeed;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        playerDefaultSpeed = playerMovement.speed;
        playerMovement.speed *= speedMult;
        Destroy(gameObject, effectDuration);
    }

    protected override void OnDestroy()
    {
        playerMovement.speed = playerDefaultSpeed;
    }
}
