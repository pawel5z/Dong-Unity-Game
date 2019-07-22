using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostsControllerBehaviour : MonoBehaviour
{
    public List<GameObject> boosts;
    public float releaseTimeLeft;
    public float releaseTimeRight;
    public int boostSpawnProbability;

    public IEnumerator Work()
    {
        if (Random.Range(1, 101) <= boostSpawnProbability)
        {
            float releaseTime = Random.Range(releaseTimeLeft, releaseTimeRight);
            while (releaseTime > 0)
            {
                releaseTime -= Time.deltaTime;
                yield return null;
            }
            Instantiate(boosts[Random.Range(0, boosts.Count)], transform);
        }
        yield return null;
    }

    public void ClearBoosts()
    {
        foreach (Transform boostTransform in transform)
            Destroy(boostTransform.gameObject);
    }
}
