using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerBehaviour : MonoBehaviour
{
    public static SoundControllerBehaviour instance = null;
    public AudioSource fxSource;
    public float pitchMultLeft;
    public float pitchMultRight;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayFxVariant(AudioClip clip)
    {
        fxSource.clip = clip;
        fxSource.pitch = Random.Range(pitchMultLeft, pitchMultRight);
        fxSource.Play();
    }
}
