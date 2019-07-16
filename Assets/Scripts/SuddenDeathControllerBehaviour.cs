using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuddenDeathControllerBehaviour : MonoBehaviour
{
    public List<GameObject> players;
    public GameObject suddenDeathText;

    public void StartSuddenDeath()
    {
        suddenDeathText.GetComponent<Animator>().SetTrigger("Sudden death");
        foreach (GameObject player in players)
        {
            player.GetComponent<PlayerMovement>().SuddenDeath();
        }
    }

    public void StopSuddenDeath()
    {
        foreach (GameObject player in players)
        {
            player.GetComponent<PlayerMovement>().Reset();
        }
    }
}
