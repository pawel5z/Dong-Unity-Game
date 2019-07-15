using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuddenDeathControllerBehaviour : MonoBehaviour
{
    public List<GameObject> players;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartSuddenDeath()
    {
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
