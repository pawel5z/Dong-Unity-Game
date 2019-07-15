using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerBehaviour : MonoBehaviour
{
    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        Application.Quit();
    }
}
