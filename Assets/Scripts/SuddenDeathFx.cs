using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuddenDeathFx : MonoBehaviour
{
    public GameObject mainCamera;

    public void TextsAlign(float screenShakeDuration)
    {
        mainCamera.GetComponent<ScreenShaker>().StartCoroutine("Shake", screenShakeDuration);
    }
}
