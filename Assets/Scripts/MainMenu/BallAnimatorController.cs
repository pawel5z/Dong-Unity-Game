using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnimatorController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public List<AudioClip> hitSounds;
    public AudioClip panelHitSound;

    public void TriggerMainMenuPanelAnimation(string name)
    {
        mainMenuPanel.GetComponent<Animator>().SetTrigger(name);
    }

    public void PlayEdgeHitSound()
    {
        SoundControllerBehaviour.instance.PlayFxVariant(hitSounds[Random.Range(0, hitSounds.Count)]);
    }

    public void PlayPanelHitSound()
    {
        SoundControllerBehaviour.instance.PlayFxVariant(panelHitSound);
    }
}
