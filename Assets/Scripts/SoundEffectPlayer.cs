using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public void PlaySoundEffect(AudioClip clip)
    {
        SoundControllerBehaviour.instance.PlayFxVariant(clip);
    }
}
