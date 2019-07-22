using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuddenDeathFx : MonoBehaviour
{
    public GameObject mainCamera;

    public void ScreenShake(float screenShakeDuration)
    {
        mainCamera.GetComponent<ScreenShaker>().StartCoroutine("Shake", screenShakeDuration);
    }
}
