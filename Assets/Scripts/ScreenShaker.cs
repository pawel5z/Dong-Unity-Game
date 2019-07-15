using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour
{
    public float shakeIntensity;
    private Vector3 defaultCamPos;

    private void Start()
    {
        defaultCamPos = this.transform.position;
    }

    public IEnumerator Shake(float time)
    {
        while (time > 0)
        {
            Vector3 tempPos = defaultCamPos + (Random.insideUnitSphere * shakeIntensity);
            this.transform.position = new Vector3(tempPos.x, tempPos.y, defaultCamPos.z);
            time -= Time.deltaTime;
            yield return null;
        }
        this.transform.position = defaultCamPos;
        yield return null;
    }
}
