using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerBehaviour : MonoBehaviour
{
    public static SoundControllerBehaviour instance = null;
    public List<AudioSource> fxSourceList;
    private int fxAsIndex = 0;
    public float pitchMultLeft;
    public float pitchMultRight;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void PlayFxVariant(AudioClip clip)
    {
        fxSourceList[fxAsIndex].clip = clip;
        fxSourceList[fxAsIndex].pitch = Random.Range(pitchMultLeft, pitchMultRight);
        fxSourceList[fxAsIndex].Play();
        fxAsIndex = (fxAsIndex + 1) % fxSourceList.Count;
    }
}
